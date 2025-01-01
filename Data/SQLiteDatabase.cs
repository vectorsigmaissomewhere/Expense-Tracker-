using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cashy.Models;
using SQLite;

namespace Cashy.Services
{
    public class SQLiteDatabase
    {
        private readonly SQLiteAsyncConnection _db;

        public SQLiteDatabase(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<User>().Wait(); // Ensure the table exists
        }

        public Task<int> InsertUserAsync(User user)
        {
            return _db.InsertAsync(user);
        }

        public Task<User?> GetUserByUsernameAsync(string username)
        {
            return _db.Table<User>().FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
