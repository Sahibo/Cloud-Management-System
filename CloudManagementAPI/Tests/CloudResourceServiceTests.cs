using Xunit;
using Moq;
using CloudManagementAPI.Interfaces;
using CloudManagementAPI.Models;
using CloudManagementAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudManagementAPI.Tests.Services
{
    public class CloudResourceServiceTests
    {
        private readonly Mock<ICloudResourceRepository> _mockRepo;
        private readonly CloudResourceService _service;

        public CloudResourceServiceTests()
        {
            _mockRepo = new Mock<ICloudResourceRepository>();
            _service = new CloudResourceService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsResources()
        {
            var resources = new List<CloudResource> { new StorageBucket { Id = 1 } };
            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(resources);

            var result = await _service.GetAllAsync();

            Assert.Equal(resources, result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsResource()
        {
            var resource = new StorageBucket { Id = 1 };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(resource);

            var result = await _service.GetByIdAsync(1);

            Assert.Equal(resource, result);
        }
    }
}