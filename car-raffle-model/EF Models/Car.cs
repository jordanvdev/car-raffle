using car_raffle_model.API_Models;

namespace car_raffle_model;

public class Car
{
    public Guid Id { get; set; }
    public Listing Listing { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public int Doors { get; set; }
    public int Horsepower { get; set; }

    public Car()
    {
        
    }

    public Car(ListingRequest listingRequest)
    {
        Make = listingRequest.Make;
        Model = listingRequest.Model;
        Year = listingRequest.Year;
        Color = listingRequest.Color;
        Doors = listingRequest.Doors;
        Horsepower = listingRequest.Horsepower;
    }
}