using System.Net;
using car_raffle_datalayer.Repository.Interfaces;
using car_raffle_model;
using car_raffle_model.API_Models;
using car_raffle_services.Services;
using car_raffle_services.Services.Interfaces;
using Moq;
using Tarkov_Info_DataLayer.Repository.Interfaces;

namespace car_raffle_unittests.Service_Tests;

public class DeleteListingTests
{
    private Mock<IListingRepository> _mockListingRepository;
    private Mock<IUserRepository> _mockUserRepository;
    private IListingService _listingService;

    [SetUp]
    public void SetUp()
    {
        _mockListingRepository = new Mock<IListingRepository>();
        _mockUserRepository = new Mock<IUserRepository>();
        _listingService = new ListingService(_mockListingRepository.Object,_mockUserRepository.Object, null);
    }
    
    [Test]
    public async Task GivenListingNotFound_WhenDeleteListingCalled_ThenBadRequestReturned()
    {
        // Arrange
        _mockListingRepository.Setup(a => a.GetListingById(It.IsAny<Guid>())).ReturnsAsync(null as Listing);
        
        // Act
        var result = await _listingService.DeleteListingAsync(Guid.NewGuid());

        // Assert
        Assert.That(result.Result, Is.False);
        Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
    
    [Test]
    public async Task GivenListingIsFound_WhenReviewListingCalled_ThenListingIsUpdated()
    {
        // Arrange
        _mockListingRepository.Setup(a => a.GetListingById(It.IsAny<Guid>())).ReturnsAsync(new Listing());
        
        // Act
        var result = await _listingService.DeleteListingAsync(Guid.NewGuid());

        // Assert
        _mockListingRepository.Verify(a => a.GetListingById(It.IsAny<Guid>()),Times.Once);
        _mockListingRepository.Verify(a => a.DeleteListingAsync(It.IsAny<Listing>()),Times.Once);
        Assert.That(result.Result, Is.True);
    }
}