using car_raffle_datalayer.Repository.Interfaces;
using car_raffle_model;
using car_raffle_services.Interfaces;
using car_raffle_services.Services;
using Moq;
using Tarkov_Info_DataLayer.Repository.Interfaces;

namespace car_raffle_unittests.Service_Tests;

public class GetAllListingTests
{
    private Mock<IListingRepository> _mockListingRepository;
    private IListingService _listingService;

    [SetUp]
    public void SetUp()
    {
        _mockListingRepository = new Mock<IListingRepository>();
        _listingService = new ListingService(_mockListingRepository.Object,null);
    }
    
    [Test]
    public async Task GivenListingsPresent_WhenGetAllListingsCalled_ThenListingsAreReturned()
    {
        // Arrange
        var listings = new List<Listing>
        {
            new() { Id = Guid.NewGuid(), Car = new Car(), User = new User()},
            new() { Id = Guid.NewGuid(), Car = new Car() , User = new User()}
        };

        _mockListingRepository.Setup(repo => repo.GetAllListingsAsync()).ReturnsAsync(listings);

        // Act
        var result = await _listingService.GetAllListingsAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.Result.Count, Is.EqualTo(2));
    }
}