using Dapper;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dapper
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IDbConnection connection):base(connection)
        {

        }
        public void Delete(long id)
        {
            if (_dbConnection.State != ConnectionState.Open)
                _dbConnection.Open();
            string SQL = $"DELETE FROM users WHERE id= {id}";
            _dbConnection.Execute(SQL);
        }

        public async Task<List<User>> GetUsers()
        {
            if (_dbConnection.State != ConnectionState.Open)
                _dbConnection.Open();
            string SQL = $"SELECT * FROM users";
            return (await _dbConnection.QueryAsync<User>(SQL)).ToList();
        }

        public async Task<bool> Insert(User user)
        {
            if (user == null)
                return false;
            if (_dbConnection.State != ConnectionState.Open)
                _dbConnection.Open();
            string SQL = $@"INSERT INTO users(username, password, fullname, role)
                            VALUES(
                            '{ user.Username}',
                            '{user.Password}',
                            '{user.FullName}',
                            {user.Role}
                            );";
            await _dbConnection.ExecuteScalarAsync<bool>(SQL);
            return true;
        }

        public void Update(User user)
        {
            if (user == null)
                return;
            if (_dbConnection.State != ConnectionState.Open)
                _dbConnection.Open();
            string SQL = $@"UPDATE users SET 
                            username = '{user.Username}',
                            password = '{user.Password}',
                            fullname = '{user.FullName}',
                            role = {user.Role} 
                            WHERE id = {user.ID};";
            _dbConnection.Execute(SQL);
        }
    }
}
