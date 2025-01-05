using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Cashy.Models;

namespace Cashy.Services
{
    public class TransactionService
    {
        private readonly SQLiteAsyncConnection _db;

        public TransactionService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Transaction>().Wait(); // Ensure the Transactions table exists
        }

        public Task<int> AddTransactionAsync(Transaction transaction)
        {
            return _db.InsertAsync(transaction);
        }

        public Task<List<Transaction>> GetTransactionsByUserIdAsync(int userId)
        {
            return _db.Table<Transaction>().Where(t => t.UserId == userId).ToListAsync();
        }

        public Task<int> DeleteTransactionAsync(int transactionId)
        {
            return _db.Table<Transaction>().DeleteAsync(t => t.Id == transactionId);
        }
    }
}
