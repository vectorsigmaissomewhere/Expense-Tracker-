using Cashy.Models;

namespace Cashy.Services
{
    public class SessionService
    {
        private readonly SQLiteDatabase _sqliteDatabase;

        public SessionService(SQLiteDatabase sqliteDatabase)
        {
            _sqliteDatabase = sqliteDatabase;
        }

        public async Task SetSessionData(string key, string value)
        {
            if (key.Length > 50 || value.Length > 50)
            {
                throw new ArgumentException("Key or Value exceeds the maximum allowed length of 50 characters.");
            }

            try
            {
                var session = new Session
                {
                    SessionID = 0, // Default SessionID
                    Key = key,
                    Value = value,
                    LastUpdated = DateTime.UtcNow.ToString("o") // ISO 8601 format
                };

                await _sqliteDatabase.InsertSessionAsync(session);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to set session data for key: {key}", ex);
            }
        }

        public async Task<string> GetSessionData(string key)
        {
            try
            {
                var session = await _sqliteDatabase.GetSessionByKeyAsync(key);

                // Return the value if it exists, otherwise return empty string
                return session?.Value ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving session data: {ex.Message}");
                return string.Empty;
            }
        }

        public async Task RemoveSessionData(string key)
        {
            try
            {
                // Remove the session data with the specified key
                await _sqliteDatabase.DeleteSessionAsync(key);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to remove session data for key: {key}", ex);
            }
        }
    }
}
