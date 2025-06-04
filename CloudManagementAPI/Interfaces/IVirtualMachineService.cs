using CloudManagementAPI.Models;

namespace CloudManagementAPI.Interfaces
{
    public interface IVirtualMachineService
    {
        Task<List<VirtualMachine>> GetAllAsync();
        Task<VirtualMachine?> GetByIdAsync(int id);
        Task AddAsync(VirtualMachine vm);
        Task UpdateAsync(VirtualMachine vm);
        Task DeleteAsync(int id);
    }
}
