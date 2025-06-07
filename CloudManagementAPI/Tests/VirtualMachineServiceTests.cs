using Xunit;
using Moq;
using CloudManagementAPI.Models;
using CloudManagementAPI.Services;
using CloudManagementAPI.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudManagementAPI.Tests.Services
{
    public class VirtualMachineServiceTests
    {
        private readonly Mock<IVirtualMachineRepository> _mockRepo;
        private readonly VirtualMachineService _service;

        public VirtualMachineServiceTests()
        {
            _mockRepo = new Mock<IVirtualMachineRepository>();
            _service = new VirtualMachineService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsVMs()
        {
            var vms = new List<VirtualMachine> { new VirtualMachine { Id = 1 } };
            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(vms);

            var result = await _service.GetAllAsync();

            Assert.Equal(vms, result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsVM()
        {
            var vm = new VirtualMachine { Id = 1 };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(vm);

            var result = await _service.GetByIdAsync(1);

            Assert.Equal(vm, result);
        }

        [Fact]
        public async Task AddAsync_CallsRepoAddAndSave()
        {
            var vm = new VirtualMachine { Name = "VM-Test" };

            await _service.AddAsync(vm);

            _mockRepo.Verify(r => r.AddAsync(vm), Times.Once);
            _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_CallsRepoUpdateAndSave()
        {
            var vm = new VirtualMachine { Id = 1, Name = "Updated VM" };

            await _service.UpdateAsync(vm);

            _mockRepo.Verify(r => r.UpdateAsync(vm), Times.Once);
            _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_CallsRepoDeleteAndSave()
        {
            var id = 1;
            await _service.DeleteAsync(id);

            _mockRepo.Verify(r => r.DeleteAsync(id), Times.Once);
            _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }


        [Fact]
        public void PerformVirtualMachineAction_Start_ReturnsStartingMessage()
        {
            var mockRepo = new Mock<IVirtualMachineRepository>();
            var service = new VirtualMachineService(mockRepo.Object);
            var vm = new VirtualMachine { Name = "TestVM", OS = "Linux", CPUCores = 4, RAMGb = 8, Region = "Poland" };

            var result = service.PerformVirtualMachineAction(vm, "start");

            Assert.Equal("Virtual Machine 'TestVM' is starting...", result);
        }

        [Fact]
        public void PerformVirtualMachineAction_Stop_ReturnsStoppingMessage()
        {
            var mockRepo = new Mock<IVirtualMachineRepository>();
            var service = new VirtualMachineService(mockRepo.Object);
            var vm = new VirtualMachine { Name = "TestVM", OS = "Linux", CPUCores = 4, RAMGb = 8, Region = "Poland" };

            var result = service.PerformVirtualMachineAction(vm, "stop");

            Assert.Equal("Virtual Machine 'TestVM' is stopping...", result);
        }

        [Fact]
        public void PerformVirtualMachineAction_UnknownAction_ReturnsUnknownMessage()
        {
            var mockRepo = new Mock<IVirtualMachineRepository>();
            var service = new VirtualMachineService(mockRepo.Object);
            var vm = new VirtualMachine { Name = "TestVM", OS = "Linux", CPUCores = 4, RAMGb = 8, Region = "Poland" };

            var result = service.PerformVirtualMachineAction(vm, "unknown_action");

            Assert.Equal("Unknown action 'unknown_action' for Virtual Machine 'TestVM'.", result);
        }
    }
}
