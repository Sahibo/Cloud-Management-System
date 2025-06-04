using CloudManagementAPI.Data;
using CloudManagementAPI.Interfaces;
using CloudManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudManagementAPI.Repositories
{
    public class CloudResourceRepository : ICloudResourceRepository
    {
        private readonly ApplicationDbContext _context;

        public CloudResourceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CloudResource>> GetAllAsync()
        {
            return await _context.CloudResources.ToListAsync();
        }

        public async Task<CloudResource?> GetByIdAsync(int id)
        {
            return await _context.CloudResources.FindAsync(id);
        }
    }
}
