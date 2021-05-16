using Domain.Entities;
using Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ADO.Net
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;

        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void Delete(long id)
        {
            string connectionString = configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string SQL = $"DELETE FROM users WHERE id= {id}";

                using (SqlCommand command = new SqlCommand(SQL, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public Task<List<User>> GetUsers()
        {
            var users = new List<User>();

            string connectionString = configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string SQL = $"SELECT * FROM users";

                using (SqlCommand command = new SqlCommand(SQL, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User();
                            user.ID = Convert.ToInt32(reader["id"]);
                            user.Username = Convert.ToString(reader["username"]);
                            user.FullName = Convert.ToString(reader["fullName"]);
                            user.Password = Convert.ToString(reader["password"]);
                            user.Role = Convert.ToInt32(reader["role"]);
                            users.Add(user);
                        }
                    }
                    connection.Close();
                }
            }

            return Task.FromResult(users);
        }

        public async Task<bool> Insert(User user)
        {
            string connectionString = configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string SQL = $@"INSERT INTO users(username, password, fullname, role)
                            VALUES(
                            '{ user.Username}',
                            '{user.Password}',
                            '{user.FullName}',
                            {user.Role}
                            );";

                using (SqlCommand command = new SqlCommand(SQL, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    await command.ExecuteScalarAsync();
                    connection.Close();
                }
            }

            return true;
        }

        public void Update(User user)
        {
            string connectionString = configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string SQL = $@"UPDATE users SET 
                            username = '{user.Username}',
                            password = '{user.Password}',
                            fullname = '{user.FullName}',
                            role = {user.Role} 
                            WHERE id = {user.ID};";

                using (SqlCommand command = new SqlCommand(SQL, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
