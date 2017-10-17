using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Domain.Model;

namespace OnlineStore.Domain.View
{
    public interface IProduct
    {
        IEnumerable<Product> Products { get; }

    }
}
