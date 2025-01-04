using Cashy.Models;
using SQLite;

namespace Cashy.Services
{
    public class SQLiteDatabase
    {
        private readonly SQLiteAsyncConnection _db;

        public SQLiteDatabase(string dbPath)
        {
            try
            {
                _db = new SQLiteAsyncConnection(dbPath);
                _db.CreateTableAsync<User>().Wait();
                _db.CreateTableAsync<Session>().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database initialization error: {ex.Message}");
                throw;
            }
        }

        public Task<int> InsertUserAsync(User user)
        {
            return _db.InsertAsync(user);
        }

        public Task<User?> GetUserByUsernameAsync(string username)
        {
            return _db.Table<User>().FirstOrDefaultAsync(u => u.Username == username);
        }

        // Ensure that the Sessions table exists and is properly set up 
        public Task<int> InsertSessionAsync(Session session)
        {
            return _db.InsertOrReplaceAsync(session);
        }

        public Task<Session?> GetSessionByKeyAsync(string key)
        {
            return _db.Table<Session>().FirstOrDefaultAsync(s => s.Key == key && s.SessionID == 0);
        }

        public Task<int> DeleteSessionAsync(string key)
        {
            return _db.Table<Session>().DeleteAsync(s => s.Key == key && s.SessionID == 0);
        }
    }
}
