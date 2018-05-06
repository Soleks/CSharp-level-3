using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace DbCrud
{
    class DbClient
    {
        private ObservableCollection<Department> _department = new ObservableCollection<Department>();

        public ObservableCollection<Department> Select()
        {
            string sqlQuery =
                @"SELECT Department, FirstName, LastName FROM Lesson7";

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
                        string Department = reader.GetString(0);
                        string FirstName = reader.GetString(1);
                        string LastName = reader.GetString(2);

                        _department.Add(
                                 new Department(Department, new Employee() { Name = FirstName, LastName = LastName }));
                    }
                }

                reader.Close();

                return _department;
            }
        }

    }
}
