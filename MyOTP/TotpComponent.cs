using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.Reflection;


namespace MyOTP
{
    public partial class TotpComponent : UserControl
    {
        private readonly TotpObject _totp;
        private readonly string _dbFile;
        private readonly FormMain _parent;

        public TotpComponent(TotpObject totpObject, string dbFile, FormMain parent)
        {
            this.DoubleBuffered = true;

            _totp = totpObject;
            _dbFile = dbFile;
            _parent = parent;

            InitializeComponent();

            typeof(Panel).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                panel1,
                new object[] { true });

            lbAppName.Text = _totp.AppName;
            lbUserName.Text = _totp.UserName;
            lbTotpCode.Text = _totp.Token;

            DrawLines();

            if (!String.IsNullOrEmpty(_totp.Url))
            {
                lbAppName.ForeColor = Color.Blue;
                lbAppName.Click += delegate
                {
                    try
                    {
                        Clipboard.SetText(lbTotpCode.Text);
                        Process.Start(new ProcessStartInfo(_totp.Url) { UseShellExecute = true });
                    }
                    catch { }
                };
            }
            timer1.Start();
        }

        private void RefreshTotp()
        {
            lbTotpCode.Text = _totp.Token;
            lbRemaining.Text = $"({_totp.Remaining})";
            lbRemaining.Left = lbTotpCode.Width + 10;
            DrawLines();
            DrawPie(panel1, (float)_totp.Remaining / (float)_totp.Step);
        }

        private void LbTotpCode_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lbTotpCode.Text);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this application entry?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var connectionString = new SqliteConnectionStringBuilder($"Data Source={_dbFile}")
                {
                    Mode = SqliteOpenMode.ReadWrite,
                    Password = Properties.Resources.SqlitePassword
                }.ToString();

                using var connection = new SqliteConnection(connectionString);
                connection.Open();
                var commandText = @"DELETE FROM apps WHERE key=@key;";
                using var command = connection.CreateCommand();
                command.CommandText = commandText;
                command.Parameters.Add(new SqliteParameter("@key", _totp.Key));
                try
                {
                    command.ExecuteNonQuery();
                    _parent.LoadComponents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error :" + ex.Message);
                }
            }
        }

        private static void DrawLine(Control area, Brush? brush, float? width)
        {
            using Graphics g = area.CreateGraphics();
            Pen pen = brush != null ? new Pen(brush) : new Pen(Brushes.Black);
            pen.Width = width == null ? 1.0f : width.Value;
            int x1 = 0, y1 = area.Height - 1, x2 = area.Width, y2 = area.Height - 1;
            g.DrawLine(pen, x1, y1, x2, y2);
            pen.Dispose();
        }

        private void DrawLines()
        {
            DrawLine(panel1, Brushes.SteelBlue, 1.0f);
            DrawLine(panel2, Brushes.SteelBlue, 1.0f);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            RefreshTotp();
            Invalidate();
        }

        private void DrawPie(Panel parent, float progress, float angleShift = -90f)
        {
            parent.SuspendLayout();

            // Create pen.
            SolidBrush brush = new SolidBrush(Color.SteelBlue);

            Rectangle rect = parent.DisplayRectangle;

            rect.Width = Math.Min(rect.Width, rect.Height);
            rect.Height = Math.Min(rect.Width, rect.Height);
            rect.Width = rect.Width - 1;
            rect.Height = rect.Height - 1;

            // Create start and sweep angles.
            float startAngle = angleShift;
            float sweepAngle = progress * 360f;

            Debug.WriteLine(sweepAngle + " " + rect.X + " " + rect.Y + " " + rect.Width + " " + rect.Height);

            // Draw pie to screen.
            parent.Refresh();
            var graphics = parent.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.FillPie(brush, rect, startAngle, sweepAngle);
            parent.ResumeLayout();
        }
    }
}
