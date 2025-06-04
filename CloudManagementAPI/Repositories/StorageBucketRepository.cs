using CloudManagementAPI.Data;
using CloudManagementAPI.Interfaces;
using CloudManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudManagementAPI.Repositories
{
    public class StorageBucketRepository : IStorageBucketRepository
    {
        private readonly ApplicationDbContext _context;

        public StorageBucketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<StorageBucket>> GetAllAsync() =>
            await _context.StorageBuckets.ToListAsync();

        public async Task<StorageBucket?> GetByIdAsync(int id) =>
            await _context.StorageBuckets.FindAsync(id);

        public async Task AddAsync(StorageBucket bucket)
        {
            _context.StorageBuckets.Add(bucket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StorageBucket bucket)
        {
            _context.StorageBuckets.Update(bucket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bucket = await GetByIdAsync(id);
            if (bucket != null)
            {
                _context.StorageBuckets.Remove(bucket);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
