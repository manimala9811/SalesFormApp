using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SalesFormApp.Models;
using SalesFormApp.ViewModels;

namespace SalesFormApp.Controllers
{
    public class SalesController : Controller
    {
        private static List<SalesDetail> _savedSales = new List<SalesDetail>();

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new SalesFormViewModel
            {
                Users      = StaticData.GetUsers(),
                Countries  = StaticData.GetCountries(),
                Cities     = StaticData.GetCities(),
                Products   = StaticData.GetProducts(),
                SavedSales = _savedSales
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(SalesFormViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _savedSales.Add(vm.SalesDetail);
                TempData["SuccessMessage"] = "Sales data submitted successfully!";
                return RedirectToAction("Create");
            }

            // Repopulate dropdowns on error
            vm.Users      = StaticData.GetUsers();
            vm.Countries  = StaticData.GetCountries();
            vm.Cities     = StaticData.GetCities();
            vm.Products   = StaticData.GetProducts();
            vm.SavedSales = _savedSales;
            return View(vm);
        }

        [HttpGet]
         public IActionResult List(int countryId)
        {
            // Always return an array (possibly empty), never an error object
            var result = _savedSales
                .Where(r => r.SalesItems.Any(si => si.CountryId == countryId))
                .Select(r => new 
                {
                    Date      = r.Date,
                    UserName  = StaticData.GetUsers().First(u => u.Id == r.UserId).Name,
                    SalesItems = r.SalesItems.Select(si => new 
                    {
                        si.QtySold,
                        si.Amount,
                        ProductName = StaticData.GetProducts().First(p => p.Id == si.ProductId).Name,
                        CityName    = StaticData.GetCities().First(c => c.Id == si.CityId).Name
                    })
                })
                .ToList();

            return Json(result);
        }
    }
}
