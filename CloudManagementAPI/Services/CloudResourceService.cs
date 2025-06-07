using CloudManagementAPI.Interfaces;
using CloudManagementAPI.Models;

namespace CloudManagementAPI.Services
{
    public class CloudResourceService : ICloudResourceService
    {
        private readonly ICloudResourceRepository _repository;

        public CloudResourceService(ICloudResourceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CloudResource>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        
        public async Task<CloudResource?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public string GetCloudResourceDetails(CloudResource resource)
        {
            return resource.GetResourceDetails();
        }
        public string PerformCloudResourceAction(CloudResource resource, string actionType)
        {
            return resource.PerformAction(actionType);
        }

    }
}
