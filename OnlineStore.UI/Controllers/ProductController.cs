using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Domain.View;
using OnlineStore.UI.Models;

namespace OnlineStore.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct repository;
        public int pageSize = 4;
        public ProductController(IProduct repos)
        {
            repository = repos;
        }
        public ViewResult List(string category, int page=1)
        {
            ProductList model = new ProductList
            {
                Products = repository.Products
                .Where(p => category == null || p.Category==category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                pageInfo = new PageInfo
                {
                    currentPage = page,
                    itemsPerPage = pageSize,
                    totalItems = category==null ?repository.Products.Count() 
                    :repository.Products.Where(p=>p.Category==category).Count()
                },
                currentCategory=category
            };
            return View(model);
        }
    }
}