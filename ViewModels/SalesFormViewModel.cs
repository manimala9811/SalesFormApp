using System.Collections.Generic;
using SalesFormApp.Models;

namespace SalesFormApp.ViewModels
{
    public class SalesFormViewModel
    {
        public SalesDetail SalesDetail { get; set; } = new SalesDetail
        {
            SalesItems = new List<SalesItem>()
        };

        public List<User> Users { get; set; } = new List<User>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<City> Cities { get; set; } = new List<City>();

        // previously saved submissions
        public List<SalesDetail> SavedSales { get; set; } = new List<SalesDetail>();
    }
}