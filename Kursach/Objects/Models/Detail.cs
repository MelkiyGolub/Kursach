namespace Kursach.Objects.Models;

public class Detail
{
    public int ID { get; set; }
    public string? Type { get; init; }
    public string? Model { get; init; }
    public int Amount { get; set; }
    public int Price { get; init; }
}