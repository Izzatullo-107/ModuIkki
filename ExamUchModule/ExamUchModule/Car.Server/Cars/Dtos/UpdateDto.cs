namespace Car.Server.Cars.Dtos;

public class UpdateDto
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int TrimLevel { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public int Price { get; set; }
    public int? Mileage { get; set; }
}
