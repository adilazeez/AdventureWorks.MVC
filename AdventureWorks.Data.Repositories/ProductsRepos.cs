using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.EF.Data;

namespace AdventureWorks.Data.Repositories
{
    public interface IProductsRepos
    {
        int NoOfProducts { get; }
        List<AdventureWorks.EF.Data.Product> GetAllProductsForSubCategory();
        AdventureWorks.EF.Data.Product GetProductByID(int productID);
    }

    public class ProductsRepos : IProductsRepos
    {
        AdventureWorks.EF.Data.AdventureWorksDataEntities awContext = new AdventureWorksDataEntities();
        List<AdventureWorks.EF.Data.Product> products;

        public ProductsRepos(int subcategoryID)
        {
            products = awContext.Products.Where(t => t.ProductSubcategoryID == subcategoryID).ToList();
            NoOfProducts = products.Count;
        }

        public int NoOfProducts { get; }

        public List<Product> GetAllProductsForSubCategory()
        {
            return products;
        }

        public Product GetProductByID(int productID)
        {
            return products.FirstOrDefault(t => t.ProductID == productID);
        }
    }
}
