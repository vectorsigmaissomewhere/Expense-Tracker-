using Cashy.Models;

namespace Cashy.Services
{
    public class UserService
    {
        private readonly SQLiteDatabase _database;

        public UserService(SQLiteDatabase database)
        {
            _database = database;
        }

        public async Task<bool> SignUpAsync(User user)
        {
            try
            {
                // Hash the password before saving
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                // Check if username already exists
                var existingUser = await _database.GetUserByUsernameAsync(user.Username);
                if (existingUser != null)
                {
                    throw new Exception("Username already exists.");
                }

                var result = await _database.InsertUserAsync(user);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> LoginAsync(User user)
        {
            try
            {
                // Retrieve user from database
                var existingUser = await _database.GetUserByUsernameAsync(user.Username);
                if (existingUser == null)
                {
                    return false; // User does not exist
                }

                // Verify the password
                var isPasswordValid = BCrypt.Net.BCrypt.Verify(user.Password, existingUser.Password);
                return isPasswordValid;
            }
            catch
            {
                return false;
            }
        }
    }
}
