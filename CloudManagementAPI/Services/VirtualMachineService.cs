using CloudManagementAPI.Interfaces;
using CloudManagementAPI.Models;

namespace CloudManagementAPI.Services
{
    public class VirtualMachineService : IVirtualMachineService
    {
        private readonly IVirtualMachineRepository _repository;

        public VirtualMachineService(IVirtualMachineRepository repository)
        {
            _repository = repository;
        }

        public Task<List<VirtualMachine>> GetAllAsync() =>
            _repository.GetAllAsync();

        public Task<VirtualMachine?> GetByIdAsync(int id) =>
            _repository.GetByIdAsync(id);

        public async Task AddAsync(VirtualMachine vm)
        {
            await _repository.AddAsync(vm);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(VirtualMachine vm)
        {
            await _repository.UpdateAsync(vm);
            await _repository.SaveChangesAsync();
        }
    }
}
