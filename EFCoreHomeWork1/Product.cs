using System.Collections.Generic;

public class Product
{
    public int ID { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public ICollection<Order> Orders { get; set; }
}