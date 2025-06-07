using CloudManagementAPI.Models;

namespace CloudManagementAPI.Interfaces
{
    public interface ICloudResourceService
    {
        Task<List<CloudResource>> GetAllAsync();
        Task<CloudResource?> GetByIdAsync(int id);

        string GetCloudResourceDetails(CloudResource resource);

        string PerformCloudResourceAction(CloudResource resource, string actionType);

    }
}
