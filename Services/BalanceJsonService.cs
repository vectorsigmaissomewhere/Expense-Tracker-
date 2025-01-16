using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cashy.Services
{
    public class BalanceJsonService
    {
        private readonly string BalanceFilePath;

        public BalanceJsonService()
        {
            // Set the custom path for balance.json
            BalanceFilePath = Path.Combine("D:", "somedata", "balance.json");

            // Ensure the directory exists
            var directory = Path.GetDirectoryName(BalanceFilePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public async Task<decimal> GetBalanceAsync()
        {
            if (!File.Exists(BalanceFilePath))
            {
                // Initialize with a balance of 0 if the file doesn't exist.
                await UpdateBalanceAsync(0);
                return 0;
            }

            var balanceJson = await File.ReadAllTextAsync(BalanceFilePath);
            return JsonSerializer.Deserialize<decimal>(balanceJson);
        }

        public async Task UpdateBalanceAsync(decimal newBalance)
        {
            var balanceJson = JsonSerializer.Serialize(newBalance);
            await File.WriteAllTextAsync(BalanceFilePath, balanceJson);
        }

        public async Task<bool> HasSufficientBalanceAsync(decimal amount)
        {
            var currentBalance = await GetBalanceAsync();
            return amount <= currentBalance;
        }
    }
}
