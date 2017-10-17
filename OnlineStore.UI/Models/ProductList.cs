using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineStore.Domain.Model;

namespace OnlineStore.UI.Models
{
    public class ProductList
    {
        public IEnumerable<Product> Products { get; set; }
        public PageInfo pageInfo { get; set; }
        public string currentCategory { get; set; }
    }
}