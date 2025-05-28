using Microsoft.Data.Sqlite;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Dwm;

namespace MyOTP
{
    public partial class FormMain : Form
    {
        const string dbFile = "mytotp.sqlite";
        List<TotpObject> totpObjects = [];

        /// <summary>
        /// Main Window. It initializes the components, sets the window attributes to prevent peeking and freezing the representation, and loads the TOTP components from the database.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            LoadComponents();
            unsafe
            {
                uint t = 1;
                var i = (void*)&t;
                _ = PInvoke.DwmSetWindowAttribute(new HWND(this.Handle), DWMWINDOWATTRIBUTE.DWMWA_DISALLOW_PEEK, i, (uint)Marshal.SizeOf(t));
                _ = PInvoke.DwmSetWindowAttribute(new HWND(this.Handle), DWMWINDOWATTRIBUTE.DWMWA_FREEZE_REPRESENTATION, i, (uint)Marshal.SizeOf(t));
                Console.WriteLine("pouet");
            }
        }

        /// <summary>
        /// Resizes the main window to accomodate the quantity of totp components and relocates it to the bottom right corner of the screen.
        /// </summary>
        private void ResizeAndRelocateWindow()
        {
            try { this.SizeChanged -= FormMain_SizeChanged; } catch { }
            this.SuspendLayout();
            this.Height = 0;
            this.Height = this.RectangleToScreen(this.ClientRectangle).Top - this.Top;
            this.Height += buttonAdd.Height;

            foreach (var truc in panelTotpComp.Controls.OfType<TotpComponent>())
            {
                this.Height += truc.Height;
                panelTotpComp.Height += truc.Height;
            }
            this.Height = Math.Max(140, this.Height);

            var rect = Screen.FromControl(this).WorkingArea;
            this.Location = new Point(rect.Width - this.Width + 1, rect.Height - this.Height + 1);
        }

        /// <summary>
        /// <para>To prevent possible data leaks, TOTP components are loaded from the database only when the form is shown or resized.</para>
        /// <para>This routine loads the entries from the database and creates a new totp component per valid entry.</para>
        /// </summary>
        public void LoadComponents()
        {
            //a bit of UI update
            try { this.SizeChanged -= FormMain_SizeChanged; } catch { }
            this.SuspendLayout();

            // just set it to visible in case the method is called after deleting the last Application in the databse
            lblNoApp.Visible = true;

            // delete all TotpComponents, they will be recreated later if needed
            while (panelTotpComp.Controls.OfType<TotpComponent>().Any())
            {
                foreach (var truc in panelTotpComp.Controls.OfType<TotpComponent>())
                {
                    panelTotpComp.Controls.Remove(truc);
                    truc.Dispose();
                }
            }

            // clear the list of totpobjects already in memory
            totpObjects.Clear();
            // read the database to get the applications details
            totpObjects = LoadDatabase();

            //if some applications are found in the database
            if (totpObjects.Count != 0)
            {
                lblNoApp.Text = "Loading, please wait";
                // hide the label, the user has already something
                lblNoApp.Visible = false;

                // create totpcomponents for each totpobject
                foreach (var totpObject in totpObjects)
                {
                    TotpComponent totpComponent = new(totpObject, dbFile, this)
                    {
                        Anchor = AnchorStyles.Top | AnchorStyles.Left,
                        Dock = DockStyle.Top
                    };
                    panelTotpComp.Controls.Add(totpComponent);
                    //totpComponent.SendToBack();
                }
            }

            // if there are no totp component, the form would be too small, so let's set it to at least 140 height

            this.Show();
            this.ResizeAndRelocateWindow();
            this.ResumeLayout();
            this.Focus();
            try { this.SizeChanged += new EventHandler(this.FormMain_SizeChanged); } catch { }
        }

        /// <summary>
        /// Reads the database and returns a list of TotpObject containing all the applications found in the database.
        /// </summary>
        /// <returns></returns>
        private static List<TotpObject> LoadDatabase()
        {
            List<TotpObject> result = [];

            if (!DatabaseExists()) Environment.Exit(1);
            var connectionString = new SqliteConnectionStringBuilder($"Data Source={dbFile}")
            {
                Mode = SqliteOpenMode.ReadOnly,
                Password = Properties.Resources.SqlitePassword
            }.ToString();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var commandText = @"SELECT * FROM apps;";
                using var command = connection.CreateCommand();
                command.CommandText = commandText;
                try
                {
                    var rdr = command.ExecuteReader();

                    int colId = rdr.GetOrdinal("id");
                    int colApp = rdr.GetOrdinal("app");
                    int colKey = rdr.GetOrdinal("key");
                    int colStep = rdr.GetOrdinal("step");
                    int colHashmode = rdr.GetOrdinal("hashmode");
                    int colSize = rdr.GetOrdinal("size");
                    int colUserName = rdr.GetOrdinal("username");
                    int colUrl = rdr.GetOrdinal("url");

                    while (rdr.Read())
                    {
                        result.Add(new TotpObject(
                            (rdr[colId].GetType() != typeof(DBNull)) ? rdr.GetInt16(colId) : 9999,
                            (rdr[colApp].GetType() != typeof(DBNull)) ? rdr.GetString(colApp) : string.Empty,
                            (rdr[colKey].GetType() != typeof(DBNull)) ? rdr.GetString(colKey) : string.Empty,
                            (rdr[colStep].GetType() != typeof(DBNull)) ? rdr.GetInt16(colStep) : 9999,
                            (rdr[colHashmode].GetType() != typeof(DBNull)) ? rdr.GetString(colHashmode) : string.Empty,
                            (rdr[colSize].GetType() != typeof(DBNull)) ? rdr.GetInt16(colSize) : 9999,
                            (rdr[colUserName].GetType() != typeof(DBNull)) ? rdr.GetString(colUserName) : string.Empty,
                            (rdr[colUrl].GetType() != typeof(DBNull)) ? rdr.GetString(colUrl) : string.Empty
                        ));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error : " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return result;
        }

        /// <summary>
        /// Checks the existence of the database file and creates the table if it does not exist.
        /// </summary>
        /// <returns>true if the database exists and is valid, false otherwise</returns>
        private static bool DatabaseExists()
        {
            var connectionString = new SqliteConnectionStringBuilder($"Data Source={dbFile}")
            {
                Mode = SqliteOpenMode.ReadWriteCreate,
                Password = Properties.Resources.SqlitePassword
            }.ToString();

            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var commandText = @"CREATE TABLE IF NOT EXISTS ""apps"" (
	                                            ""id""	INTEGER NOT NULL,
	                                            ""app""	TEXT NOT NULL,
	                                            ""key""	TEXT NOT NULL,
	                                            ""step""	TEXT NOT NULL,
	                                            ""hashmode""	TEXT NOT NULL,
	                                            ""size""	INTEGER NOT NULL,
	                                            ""username""	TEXT,
                                                ""url""	TEXT,
	                                            PRIMARY KEY(""id"" AUTOINCREMENT));";
            using var command = connection.CreateCommand();
            command.CommandText = commandText;
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error : " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Handles a left click on the notify icon in the system tray. It will restore the main form and reload the components.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //this.Show();
                this.WindowState = FormWindowState.Normal;
                LoadComponents();
            }
        }

        /// <summary>
        /// When the application is closed by clikcing the X at the top right corner, it will not close but minimize to the system tray instead.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            totpObjects.Clear();
            while (this.Controls.OfType<TotpComponent>().Any())
            {
                foreach (var truc in this.Controls.OfType<TotpComponent>())
                {
                    this.Controls.Remove(truc);
                    truc.Dispose();
                }
            }
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Handles clik on the "Add" button to open the FormAddNew dialog for adding a new TOTP application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            FormAddNew formAddNew = new(dbFile);
            formAddNew.ShowDialog();
            LoadComponents();
        }

        /// <summary>
        /// Handles the user clicking on the "Quit" menu item in the context menu of the notify icon.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Icon?.Dispose();
            notifyIcon1.Dispose();
            Environment.Exit(0);
        }

        /// <summary>
        /// Reloads the totp components on resizing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_SizeChanged(object? sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) LoadComponents();
        }

        /// <summary>
        /// intercepts the FormDeactivate event (when the window loses focus), and forwards it to the FormClosing event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            var ec = new FormClosingEventArgs(
                CloseReason.UserClosing,
                false
            );
            FormMain_FormClosing(sender, ec);
        }
    }
}