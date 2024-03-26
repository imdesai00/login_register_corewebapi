using login_register_corewebapi.Models;
using Npgsql;

namespace login_register_corewebapi.DataAccess
{
    public interface IRegisterDataAccess
    {
        void createuser(User user);

    }
    public class RegisterDataAccess : IRegisterDataAccess
    {
        private readonly string _connectionString;

        public RegisterDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("postgre");
        }

        public void createuser(User user)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("insert into \"Users\" (\"UserName\",\"PhoneNo\",\"Email\",\"Password\") values (@username,@phoneno,@email,@password);", connection))
                {
                    command.Parameters.AddWithValue("@username", user.UserName);
                    command.Parameters.AddWithValue("@phoneno", user.PhoneNo);
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
