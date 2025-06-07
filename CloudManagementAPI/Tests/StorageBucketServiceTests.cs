using Xunit;
using Moq;
using CloudManagementAPI.Models;
using CloudManagementAPI.Interfaces;
using CloudManagementAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudManagementAPI.Tests.Services
{
    public class StorageBucketServiceTests
    {
        private readonly Mock<IStorageBucketRepository> _mockRepo;
        private readonly StorageBucketService _service;

        public StorageBucketServiceTests()
        {
            _mockRepo = new Mock<IStorageBucketRepository>();
            _service = new StorageBucketService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsBuckets()
        {
            var buckets = new List<StorageBucket> { new StorageBucket { Id = 1 } };
            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(buckets);

            var result = await _service.GetAllAsync();

            Assert.Equal(buckets, result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsBucket()
        {
            var bucket = new StorageBucket { Id = 1 };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(bucket);

            var result = await _service.GetByIdAsync(1);

            Assert.Equal(bucket, result);
        }

        [Fact]
        public async Task AddAsync_CallsRepoAddAndSave()
        {
            var bucket = new StorageBucket { Name = "Bucket-Test" };

            await _service.AddAsync(bucket);

            _mockRepo.Verify(r => r.AddAsync(bucket), Times.Once);
            _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_CallsRepoUpdateAndSave()
        {
            var bucket = new StorageBucket { Id = 1, Name = "Updated Bucket" };

            await _service.UpdateAsync(bucket);

            _mockRepo.Verify(r => r.UpdateAsync(bucket), Times.Once);
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
        public void PerformStorageBucketAction_Upload_ReturnsInitiatingUploadMessage()
        {
            // Arrange
            var mockRepo = new Mock<IStorageBucketRepository>();
            var service = new StorageBucketService(mockRepo.Object);
            var bucket = new StorageBucket { Name = "TestBucket", CapacityGb = 100, Region = "Novigrad" };

            // Act
            var result = service.PerformStorageBucketAction(bucket, "upload");

            // Assert
            Assert.Equal("Initiating file upload to Storage Bucket 'TestBucket'.", result);
        }

        [Fact]
        public void PerformStorageBucketAction_Empty_ReturnsWarningMessage()
        {
            var mockRepo = new Mock<IStorageBucketRepository>();
            var service = new StorageBucketService(mockRepo.Object);
            var bucket = new StorageBucket { Name = "TestBucket", CapacityGb = 100, Region = "Novigrad" };

            var result = service.PerformStorageBucketAction(bucket, "empty");

            Assert.Equal("Warning: All contents of Storage Bucket 'TestBucket' are being deleted!", result);
        }

        [Fact]
        public void PerformStorageBucketAction_UnknownAction_ReturnsUnknownMessage()
        {
            var mockRepo = new Mock<IStorageBucketRepository>();
            var service = new StorageBucketService(mockRepo.Object);
            var bucket = new StorageBucket { Name = "TestBucket", CapacityGb = 100, Region = "Novigrad" };

            var result = service.PerformStorageBucketAction(bucket, "unknown_action");

            Assert.Equal("Unknown action 'unknown_action' for Storage Bucket 'TestBucket'.", result);
        }
    }
}
