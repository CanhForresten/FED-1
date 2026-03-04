using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bilvaerksted.Models;
using System.Collections.ObjectModel;

namespace Bilvaerksted.Data
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _connection;

        public Database()
        {
            var dataDir = FileSystem.AppDataDirectory;
            var databasePath = Path.Combine(dataDir, "Bilvaerksted.db");

            _connection = new SQLiteAsyncConnection(databasePath);
            
            Task.Run(async () =>
            {
                await _connection.CreateTableAsync<Job>();
                await _connection.CreateTableAsync<Invoice>();
                await _connection.CreateTableAsync<Material>();
            }).Wait();
        }

        public async Task<List<Job>> GetJobs()
        {
            return await _connection.Table<Job>().ToListAsync();
        }

        public async Task<Job> GetJob(int id)
        {
            var query = _connection.Table<Job>().Where(t => t.JobId == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> AddJob(Job job_)
        {
            return await _connection.InsertAsync(job_);
        }

        public async Task<int> DeleteJob(Job job_)
        {
            return await _connection.DeleteAsync(job_);
        }

        public async Task<int> UpdateJob(Job job_)
        {
            return await _connection.UpdateAsync(job_);
        }

        public async Task<int> ClearAllJobs()
        {
            // This deletes every row in the TodoItem table
            return await _connection.DeleteAllAsync<Job>();
        }


        // Afsnit med faktura
        public async Task SaveInvoiceAsync(Invoice invocie)
        {
            await _connection.InsertAsync(invocie);

            if(invocie.Materials != null)
            {
                foreach(var material in invocie.Materials)
                {
                    material.InvoiceId = invocie.InvoiceId;
                    await _connection.InsertAsync(material);
                }
            }
        }

        public async Task<List<Invoice>> GetInvoiceAsync()
        {
            var invoices = await _connection.Table<Invoice>().ToListAsync();

            foreach(var invoice in invoices)
            {
                var materials = await _connection.Table<Material>().Where(m => m.InvoiceId == invoice.InvoiceId).ToListAsync();

                invoice.Materials = new ObservableCollection<Material>(materials);
            }
            return invoices;
        }

    }
}
