using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Spicifications
{
    public class ProductWithTypeAndBrandSpicification : BaseSpicification<Product>
    {
        public ProductWithTypeAndBrandSpicification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}