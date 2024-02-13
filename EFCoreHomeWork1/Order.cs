using System;

public class Order
{
    public int ID { get; set; }
    public string Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int ProductID { get; set; }

    public Product Product { get; set; }
}