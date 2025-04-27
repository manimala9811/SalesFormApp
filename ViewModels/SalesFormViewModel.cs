using System.Collections.Generic;
public class SalesFormViewModel
{
    public SalesDetail SalesDetail { get; set; } = new();
    public List<User> Users { get; set; } = new();
    public List<Product> Products { get; set; } = new();
    public List<Country> Countries { get; set; } = new();
    public List<City> Cities { get; set; } = new();
}