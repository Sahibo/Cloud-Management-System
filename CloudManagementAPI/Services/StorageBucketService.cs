using CloudManagementAPI.Interfaces;
using CloudManagementAPI.Models;

namespace CloudManagementAPI.Services
{
    public class StorageBucketService : IStorageBucketService
    {
        private readonly IStorageBucketRepository _repository;

        public StorageBucketService(IStorageBucketRepository repository)
        {
            _repository = repository;
        }

        public Task<List<StorageBucket>> GetAllAsync() =>
            _repository.GetAllAsync();

        public Task<StorageBucket?> GetByIdAsync(int id) =>
            _repository.GetByIdAsync(id);

        public async Task AddAsync(StorageBucket bucket)
        {
            await _repository.AddAsync(bucket);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(StorageBucket bucket)
        {
            await _repository.UpdateAsync(bucket);
            await _repository.SaveChangesAsync();
        }

        public string GetStorageBucketDetails(StorageBucket bucket)
        {
            return bucket.GetResourceDetails();
        }
        public string PerformStorageBucketAction(StorageBucket bucket, string actionType)
        {
            return bucket.PerformAction(actionType);
        }
    }
}
