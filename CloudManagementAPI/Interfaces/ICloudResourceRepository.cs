using CloudManagementAPI.Models;

namespace CloudManagementAPI.Interfaces
{
    public interface ICloudResourceRepository
    {
        Task<List<CloudResource>> GetAllAsync();
        Task<CloudResource?> GetByIdAsync(int id);
    }
}