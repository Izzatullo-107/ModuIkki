namespace Car.Server.Cars.Dtos;

public class GetDto
{
    public int CarId { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int TrimLevel { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public int Price { get; set; }
    public int? Mileage { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
}
