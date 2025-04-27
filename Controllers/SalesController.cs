using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

public class SalesController : Controller
{
    private static List<User> _users = new()
    {
        new User { Id = 1, Name = "Mike" },
        new User { Id = 2, Name = "John" }
    };

    private static List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop" },
        new Product { Id = 2, Name = "Smart Watch" },
        new Product { Id = 3, Name = "Tablet" }
    };

    private static List<Country> _countries = new()
    {
        new Country { Id = 1, Name = "India" },
        new Country { Id = 2, Name = "China" },
        new Country { Id = 3, Name = "UAE" }
    };

    private static List<City> _cities = new()
    {
        new City { Id = 1, Name = "Delhi", CountryId = 1 },
        new City { Id = 2, Name = "Mumbai", CountryId = 1 },
        new City { Id = 3, Name = "Shanghai", CountryId = 2 },
        new City { Id = 4, Name = "Dubai", CountryId = 3 },
        new City { Id = 5, Name = "Abu Dhabi", CountryId = 3 }
    };

    private static List<SalesDetail> _savedSales = new();

    [HttpGet]
    public IActionResult Create()
    {
        var vm = new SalesFormViewModel
        {
            SalesDetail = new SalesDetail(),
            Users = _users,
            Products = _products,
            Countries = _countries,
            Cities = _cities
        };
        return View(vm);
    }

    [HttpPost]
    public IActionResult Create(SalesFormViewModel model)
    {
        if (ModelState.IsValid)
        {
            _savedSales.Add(model.SalesDetail);
            TempData["Success"] = "Data saved successfully!";
            return RedirectToAction("Create");
        }

        model.Users = _users;
        model.Products = _products;
        model.Countries = _countries;
        model.Cities = _cities;

        return View(model);
    }

    [HttpGet]
    public JsonResult GetCitiesByCountry(int countryId)
    {
        var cities = _cities.Where(c => c.CountryId == countryId).ToList();
        return Json(cities);
    }
}
