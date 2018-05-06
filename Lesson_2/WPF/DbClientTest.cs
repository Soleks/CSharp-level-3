using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WPF
{
    class DbClientTest
    {
        private ObservableCollection<Dto.Email> _emails = new ObservableCollection<Dto.Email>();
        private ObservableCollection<Dto.SmtpSettings> _smtpSettings = new ObservableCollection<Dto.SmtpSettings>();
        private string connectionString = ConfigurationManager.ConnectionStrings["Mail"].ConnectionString;

        public ObservableCollection<Dto.Email> SelectEmails()
        {
            string sqlQuery =
             @"SELECT Email, Password FROM Email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader =
                command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string email = reader.GetString(0);
                        string passwd = reader.GetString(1);
                       
                        _emails.Add(
                                 
                            new Dto.Email() { UserEmail = email, Password = passwd });
                    }
                }

                reader.Close();

                return _emails;
            }
        }

        public ObservableCollection<Dto.SmtpSettings> SelectSmtpSettings()
        {
            string sqlQuery =
                @"SELECT Email, Email, Password FROM Mail";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader =
                command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string address = reader.GetString(0);
                        int port;

                        if (!int.TryParse(reader.GetString(1), out port))
                        {
                            Console.WriteLine("Attempted conversion of '{0}' failed.",
                               reader.GetString(1) == null ? "<null>" : reader.GetString(1));
                        }

                        _smtpSettings.Add(

                            new Dto.SmtpSettings() { Address = address,  Port = port });
                    }
                }

                reader.Close();

                return _smtpSettings;
            }
        }

    }
}
