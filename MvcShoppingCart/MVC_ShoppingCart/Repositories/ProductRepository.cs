using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_ShoppingCart.ViewModels;

namespace MVC_ShoppingCart.Repositories
{
    public class ProductRepository
    {
        List<ProductViewModel> products { get; } = new List<ProductViewModel>
        {
            new ProductViewModel { ProductId="M01", ProductName="MacBook Pro 16", Title="MacBook Pro 16太空灰", Description="2019年最新款式Macbook Pro 16", Price=80000, UnitInStock=15, Photo="macbookpro.jpeg", Count=1  },
            new ProductViewModel { ProductId="I12", ProductName="iPhone 11 Pro", Title="iPhone 11 Pro 256GB", Description="iPhone 11 Pro 256GB紅色", Price=28000, UnitInStock=35, Photo="iphone.jpeg", Count=1  },
            new ProductViewModel { ProductId="P03", ProductName="iPad Pro", Title="iPad Pro 12.9吋", Description="iPad Pro 12.9吋白色, 256GB", Price=33900, UnitInStock=12, Photo="ipad.jpeg" , Count=1 },
            new ProductViewModel { ProductId="W45", ProductName="Apple Watch", Title="Apple Watch Series 5", Description="銀色鋁金屬錶殼；運動型錶帶", Price=13400, UnitInStock=25, Photo="applewatch.jpeg", Count=1  }
        };

        public List<ProductViewModel> GetAllProducts()
        {
            return products;
        }

        public ProductViewModel GetProductById(string productId)
        {
            var product = products.Where(x => x.ProductId == productId).FirstOrDefault();

            if(product==null)
            {
                return new ProductViewModel();
            }

            return product;
        }
    }
}