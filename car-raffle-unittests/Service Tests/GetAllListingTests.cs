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
        _listingService = new ListingService(_mockListingRepository.Object);
    }
    
    [Test]
    public async Task GivenListingsPresent_WhenGetAllListingsCalled_ThenListingsAreReturned()
    {
        // Arrange
        var listings = new List<Listing>
        {
            new Listing { Id = Guid.NewGuid() },
            new Listing { Id = Guid.NewGuid() }
        };

        _mockListingRepository.Setup(repo => repo.GetAllListings()).ReturnsAsync(listings);

        // Act
        var result = await _listingService.GetAllListings();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
    }
}