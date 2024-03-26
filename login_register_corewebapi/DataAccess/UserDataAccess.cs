using Npgsql;

namespace login_register_corewebapi.DataAccess
{
    public interface IUserDataAccess
    {
        bool ValidateCredentials(string username, string password);
    }
    public class UserDataAccess : IUserDataAccess
    {
        private readonly string _connectionString;

        public UserDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("postgre");

        }

        public bool ValidateCredentials(string username, string password)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT COUNT(*) FROM \"Users\" where \"UserName\" = @username and \"Password\" = @password;";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    return (Int64)command.ExecuteScalar() > 0;
                }
            }
        }
    }
}
