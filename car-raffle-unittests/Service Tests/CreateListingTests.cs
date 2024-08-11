using System.Net;
using car_raffle_datalayer.Repository.Interfaces;
using car_raffle_model;
using car_raffle_model.API_Models;
using car_raffle_services.Services;
using car_raffle_services.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Tarkov_Info_DataLayer.Repository.Interfaces;

namespace car_raffle_unittests.Service_Tests;

public class CreateListingTests
{
    private Mock<IListingRepository> _mockListingRepository;
    private Mock<IUserRepository> _mockUserRepository;
    private IListingService _listingService;
    private Mock<IValidator<ListingRequest>> _mockValidator;

    [SetUp]
    public void SetUp()
    {
        _mockListingRepository = new Mock<IListingRepository>();
        _mockUserRepository = new Mock<IUserRepository>();
        _mockValidator = new Mock<IValidator<ListingRequest>>();
        _listingService = new ListingService(_mockListingRepository.Object,_mockUserRepository.Object, _mockValidator.Object);
    }
    
    [Test]
    public async Task GivenValidationOnRequestObjectFailed_WhenCreateListingCalled_ThenBadRequestReturned()
    {
        // Arrange
        var failures = new List<ValidationFailure>
        {
            new ValidationFailure("Make", "Error")
        };
        _mockValidator.Setup(a => a.ValidateAsync(It.IsAny<ListingRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult(){Errors = failures});
        _mockUserRepository.Setup(a => a.GetUserByIdAsync(It.IsAny<Guid>())).ReturnsAsync(null as User);

        var listingRequest = new ListingRequest()
        {
            Make = "Ford",
            Model = "Fiesta",
            Color = "Black"
        };

        // Act
        var result = await _listingService.CreateListingAsync(listingRequest);

        // Assert
        Assert.That(result.Result, Is.False);
        Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
    
    [Test]
    public async Task GivenUserNotFound_WhenCreateListingCalled_ThenFalseIsReturned()
    {
        // Arrange
        _mockUserRepository.Setup(a => a.GetUserByIdAsync(It.IsAny<Guid>())).ReturnsAsync(null as User);
        _mockValidator.Setup(a => a.ValidateAsync(It.IsAny<ListingRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult(){ Errors = new List<ValidationFailure>()});

        var listingRequest = new ListingRequest()
        {
            Make = "Ford",
            Model = "Fiesta",
            Color = "Black"
        };

        // Act
        var result = await _listingService.CreateListingAsync(listingRequest);

        // Assert
        Assert.That(result.Result, Is.False);
        Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden));
    }
    
    [Test]
    public async Task GivenUserIsFound_WhenCreateListingCalled_ThenListingIsCreated()
    {
        // Arrange
        _mockUserRepository.Setup(a => a.GetUserByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new User());
        _mockValidator.Setup(a => a.ValidateAsync(It.IsAny<ListingRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult(){ Errors = new List<ValidationFailure>()});

        var listingRequest = new ListingRequest()
        {
            Make = "Ford",
            Model = "Fiesta",
            Color = "Black",
            Price = 10,
            TicketPrice = 1.5
        };

        // Act
        var result = await _listingService.CreateListingAsync(listingRequest);

        // Assert
        _mockUserRepository.Verify(a => a.GetUserByIdAsync(It.IsAny<Guid>()), Times.Once);
        _mockListingRepository.Verify(a => a.CreateListingAsync(It.IsAny<Listing>()),Times.Once);
        Assert.That(result.Result, Is.True);
    }
}