using CloudManagementAPI.Models;

namespace CloudManagementAPI.Interfaces
{
    public interface IVirtualMachineRepository
    {
        Task<List<VirtualMachine>> GetAllAsync();
        Task<VirtualMachine?> GetByIdAsync(int id);
        Task AddAsync(VirtualMachine vm);
        Task UpdateAsync(VirtualMachine vm);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
