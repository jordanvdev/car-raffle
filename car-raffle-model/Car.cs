namespace car_raffle_model;

public class Car
{
    public Guid Id { get; set; }
    public virtual Listing Listing { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public int Doors { get; set; }
    public int Horsepower { get; set; }
}