using Microsoft.Data.Sqlite;

namespace MyOTP
{
    public partial class FormAddNew : Form
    {
        private string _dbFile;

        public FormAddNew(string dbfile)
        {
            _dbFile = dbfile;
            InitializeComponent();
            tbSecretKey.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var appObject = new TotpObject()
            {
                AppName = tbAppName.Text,
                Key = tbSecretKey.Text,
                HashMode = cbHash.Text,
                UserName = tbUserName.Text,
                Url = tbUrl.Text
            };

            int i;
            try
            {
                _ = int.TryParse(tbStep.Text, out i);
                appObject.Step = i;
            }
            catch
            {
                MessageBox.Show("Step value is invalid");
            }
            try
            {
                int.TryParse(tbSize.Text, out i);
                appObject.Size = i;
            }
            catch
            {
                MessageBox.Show("Size value is invalid");
            }


            var connectionString = new SqliteConnectionStringBuilder($"Data Source={_dbFile}")
            {
                Mode = SqliteOpenMode.ReadWrite,
                Password = Properties.Resources.SqlitePassword
            }.ToString();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var commandText = @"INSERT INTO apps (app, key, step, hashmode, size, username, url) VALUES (@app, @key, @step, @hashmode, @size, @username, @url);";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.Add(new SqliteParameter("@app", appObject.AppName));
                    command.Parameters.Add(new SqliteParameter("@key", appObject.Key));
                    command.Parameters.Add(new SqliteParameter("@step", appObject.Step));
                    command.Parameters.Add(new SqliteParameter("@hashmode", appObject.HashMode));
                    command.Parameters.Add(new SqliteParameter("@size", appObject.Size));
                    command.Parameters.Add(new SqliteParameter("@username", appObject.UserName));
                    command.Parameters.Add(new SqliteParameter("@url", appObject.Url));
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Database Error");
                    }
                }
            }

            this.Close();
        }
    }
}
