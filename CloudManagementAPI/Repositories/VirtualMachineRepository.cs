using CloudManagementAPI.Data;
using CloudManagementAPI.Interfaces;
using CloudManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudManagementAPI.Repositories
{
    public class VirtualMachineRepository : IVirtualMachineRepository
    {
        private readonly ApplicationDbContext _context;

        public VirtualMachineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VirtualMachine>> GetAllAsync() =>
            await _context.VirtualMachines.ToListAsync();

        public async Task<VirtualMachine?> GetByIdAsync(int id) =>
            await _context.VirtualMachines.FindAsync(id);

        public async Task AddAsync(VirtualMachine vm)
        {
            _context.VirtualMachines.Add(vm);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VirtualMachine vm)
        {
            _context.VirtualMachines.Update(vm);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var vm = await GetByIdAsync(id);
            if (vm != null)
            {
                _context.VirtualMachines.Remove(vm);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
