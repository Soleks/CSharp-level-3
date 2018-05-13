using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MailSender
{
    public class DbClientTest
    {
        private ObservableCollection<Dto.Email> _emails;
        private ObservableCollection<Dto.SmtpSettings> _smtpSettings;
        private string connectionString;

        public DbClientTest()
        {
            _emails = new ObservableCollection<Dto.Email>();
            _smtpSettings = new ObservableCollection<Dto.SmtpSettings>();
            connectionString = ConfigurationManager.ConnectionStrings["Mail"].ConnectionString;
        }

        public ObservableCollection<Dto.Email> SelectEmails()
        {
            string sqlQuery =
             @"SELECT * FROM Email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                } catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string email = reader.GetString(1);
                       
                        _emails.Add(
                            new Dto.Email() { UserEmail = email });
                    }
                }

                reader.Close();

                return _emails;
            }
        }

        public ObservableCollection<Dto.SmtpSettings> SelectSmtpSettings()
        {
            string sqlQuery =
                @"SELECT Address, Port FROM SmtpSettings";

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
                        int port = reader.GetInt32(1);

                        _smtpSettings.Add(
                            new Dto.SmtpSettings() { Address = address,  Port = port });
                    }
                }

                reader.Close();

                return _smtpSettings;
            }
        }

        public void Insert(string email)
        {
            string sqlQuery =
                $@"INSERT INTO Email(email) VALUES('{email}')";

            Connect(sqlQuery);
        }

        private void Connect(string sqlQuery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    throw new Exception($"{e}");
                }
                
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                int number = command.ExecuteNonQuery();
            }
        }
    }
}
