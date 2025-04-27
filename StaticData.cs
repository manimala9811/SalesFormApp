using System.Collections.Generic;
using SalesFormApp.Models;  // Required for accessing Models

namespace SalesFormApp
{
    public static class StaticData
    {
        // Example Users
        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User { Id = 1, Name = "Mike" },
                new User { Id = 2, Name = "John" },
            };
        }

        // Example Products
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Laptop" },
                new Product { Id = 2, Name = "Smart Watch" },
                new Product { Id = 3, Name = "Tablet" },
            };
        }

        // Example Countries
        public static List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country { Id = 1, Name = "India" },
                new Country { Id = 2, Name = "China" },
                new Country { Id = 3, Name = "UAE" },
            };
        }

        // Example Cities
        public static List<City> GetCities()
        {
            return new List<City>
            {
                new City { Id = 1, Name = "Delhi", CountryId = 1 },
                new City { Id = 2, Name = "Mumbai", CountryId = 1 },
                new City { Id = 3, Name = "Shanghai", CountryId = 2 },
                new City { Id = 4, Name = "Dubai", CountryId = 3 },
                new City { Id = 5, Name = "Abu Dhabi", CountryId = 3 }
            };
        }
    }
}