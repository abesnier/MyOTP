using Microsoft.Data.Sqlite;

namespace MyOTP
{
    public partial class FormMain : Form
    {
        const string dbFile = "mytotp.sqlite";
        List<TotpObject> totpObjects = new();

        public FormMain()
        {
            InitializeComponent();
            LoadComponents();
        }

        private void ResizeAndRelocateWindow()
        {
            try { this.SizeChanged -= FormMain_SizeChanged; } catch { }
            this.SuspendLayout();
            this.Height = 0;
            this.Height = this.RectangleToScreen(this.ClientRectangle).Top - this.Top;
            this.Height += button1.Height;

            foreach (var truc in panelTotpComp.Controls.OfType<TotpComponent>())
            {
                this.Height += truc.Height;
                panelTotpComp.Height += truc.Height;
            }
            this.Height = Math.Max(140, this.Height);

            var rect = Screen.FromControl(this).WorkingArea;
            this.Location = new Point(rect.Width - this.Width + 1, rect.Height - this.Height + 1);
        }

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
            if (totpObjects.Any())
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

        private static List<TotpObject> LoadDatabase()
        {
            List<TotpObject> result = new();

            if (!CheckDatabase()) Environment.Exit(1);
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

        private static bool CheckDatabase()
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

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //this.Show();
                this.WindowState = FormWindowState.Normal;
                LoadComponents();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Button1_Click(object sender, EventArgs e)
        {
            FormAddNew formAddNew = new(dbFile);
            formAddNew.ShowDialog();
            LoadComponents();
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Icon?.Dispose();
            notifyIcon1.Dispose();
            Environment.Exit(0);
        }

        private void FormMain_SizeChanged(object? sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) LoadComponents();
        }
    }
}