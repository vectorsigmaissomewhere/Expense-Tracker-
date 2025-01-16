using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cashy.Services
{
    public class JsonService
    {
        // Update the path to the new directory location on D:\
        private readonly string _filePath = Path.Combine("D:", "somedata", "data.json");

        public async Task<T> ReadDataAsync<T>()
        {
            // Check if the file exists, if not return default
            if (!File.Exists(_filePath)) return default;

            // Read all content from the file asynchronously
            var json = await File.ReadAllTextAsync(_filePath);

            // Deserialize the JSON into the specified type T
            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task WriteDataAsync<T>(T data)
        {
            // Ensure the directory exists before attempting to write
            var directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory); // Create the directory if it doesn't exist
            }

            // Serialize the data to JSON
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            // Write the JSON data to the file asynchronously
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}