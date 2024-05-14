using Microsoft.EntityFrameworkCore;
using Moq;
using MockQueryable.Moq;
using MockQueryable.EntityFrameworkCore;
using TestProject.Tests.UnitTests.Infrastructure.Persistence;
using TestWebApplication.Infrastructure.Persistence.Common;
using TestWebApplication.Infrastructure.Persistence.Repositories;
using System.Net.Sockets;

namespace TestProject.Tests.Infrastructure.Persistence;

public class BaseRepositoryTests
{
    private readonly Mock<PostgresApplicationDbContext> _mockContext;
    private readonly BaseRepository<MockEntity> _repository;

    public BaseRepositoryTests()
    {
        _mockContext = new Mock<PostgresApplicationDbContext>();
        _repository = new BaseRepository<MockEntity>(_mockContext.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnEntity_WhenEntityExists()
    {
        // Arrange
        var mockSet = new List<MockEntity>
        {
            new MockEntity { Id = 1 },
            new MockEntity { Id = 2 },
            new MockEntity { Id = 3 },
        }.AsQueryable().BuildMockDbSet();

        _mockContext.Setup(c => c.Set<MockEntity>()).Returns(mockSet.Object);

        // Act
        var result = await _repository.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public async Task GetByCriteriaAsync_ReturnsEntitiesMatchingCriteria()
    {
        var mockDbSet = new List<MockEntity>
        {
            new MockEntity { Id = 1 },
            new MockEntity { Id = 2 }
        }
        .AsQueryable().BuildMockDbSet();

        _mockContext.Setup(c => c.Set<MockEntity>()).Returns(mockDbSet.Object);
        var result = await _repository.GetByCriteriaAsync(x => x.Id > 0);

        Assert.Equal(2, result.Count());
    }
}