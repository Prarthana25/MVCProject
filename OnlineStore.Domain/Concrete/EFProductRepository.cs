using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Domain.Model;
using OnlineStore.Domain.View;

namespace OnlineStore.Domain.Concrete
{
    public class EFProductRepository:IProduct
    {
        private readonly EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
