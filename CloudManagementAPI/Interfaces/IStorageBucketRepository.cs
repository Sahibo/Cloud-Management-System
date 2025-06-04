using CloudManagementAPI.Models;

namespace CloudManagementAPI.Interfaces
{
    public interface IStorageBucketRepository
    {
        Task<List<StorageBucket>> GetAllAsync();
        Task<StorageBucket?> GetByIdAsync(int id);
        Task AddAsync(StorageBucket bucket);
        Task UpdateAsync(StorageBucket bucket);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();

    }
}
