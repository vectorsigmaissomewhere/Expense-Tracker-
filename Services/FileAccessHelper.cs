using System;
using System.IO;

namespace Cashy
{
    public static class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string fullPath = Path.Combine(path, filename);

                // Log the database path
                Console.WriteLine($"Database Path: {fullPath}");

                return fullPath;
            }
            catch (PlatformNotSupportedException ex)
            {
                Console.WriteLine($"Error: The platform does not support retrieving the local application data folder. Details: {ex.Message}");
                throw new InvalidOperationException("Could not determine the local application data folder.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Error: Access to the local application data folder is denied. Details: {ex.Message}");
                throw new InvalidOperationException("Access denied to the local application data folder.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while retrieving the local application data folder. Details: {ex.Message}");
                throw; // Re-throwing the exception for higher-level handling if needed
            }
        }
    }
}
