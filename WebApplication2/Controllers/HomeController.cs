using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication2.Models;
using WebApplication2.Models.ViewModels;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 4;
        public string Category1 = "Telefon";
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }
        static int Sayac = 0;
        public ViewResult Index(string category, int productPage = 1)
        {
            if (Sayac == 0)
            {
                Sayac++;
                return View("Anasayfa", repository.Products
               .Select(x => x.Category1)
               .Distinct()
               .OrderBy(x => x));
            }
            else
                return View(new ProductsListViewModel
                {
                    Products = repository.Products
                     .Where(p => category == null || p.Category == category && p.Category1 == this.Category1)
                     .OrderBy(p => p.ProductID)
                     .Skip((productPage - 1) * PageSize)
                     .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = productPage,
                        ItemsPerPage = PageSize,
                        TotalItems = category == null ?
                             repository.Products.Count() :
                             repository.Products.Where(e =>
                             e.Category == category).Count()
                    }
                });
        }

        [HttpPost]
        public ViewResult Anasayfa(string category1)
        {
            this.Category1 = category1;

            //IEnumerable<Product> products = repository.Products
            //      .Where(p => p.Category1 == category1)
            //      .OrderBy(p => p.ProductID)
            //      .Skip((1 - 1) * PageSize)
            //      .Take(PageSize);



            //return View("Index", new ProductsListViewModel
            //{
            //    Products = products,
            //    PagingInfo = new PagingInfo
            //    {
            //        CurrentPage = 1,
            //        ItemsPerPage = PageSize,
            //        TotalItems = repository.Products.Count()
            //    }
            //});

            return Index("Telefon",1);
        }
    }
}



