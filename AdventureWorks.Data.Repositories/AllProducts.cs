using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.EF.Data;

namespace AdventureWorks.Data.Repositories
{
    public interface IAllProducts
    {
        Product GetProduct(int productID);
        List<Product> GetProductsListFilteredBySearchText(string searchText);
        List<Product> GetAllProducts();
        int NoOfProducts { get; }
    }

    public class AllProducts : IAllProducts
    {
        AdventureWorks.EF.Data.AdventureWorksDataEntities awContext = new AdventureWorksDataEntities();
        List<Product> allproducts;
        public AllProducts()
        {
            allproducts = awContext.Products.ToList();
            NoOfProducts = allproducts.Count;
        }

        public int NoOfProducts { get; }

        public List<Product> GetAllProducts()
        {
            return allproducts ;
        }

        public Product GetProduct(int productID)
        {
            return allproducts.FirstOrDefault(t=>t.ProductID==productID);
        }

        public List<Product> GetProductsListFilteredBySearchText(string searchText)
        {
            return allproducts.Where(t=>t.Name.Contains(searchText)).ToList();
        }
    }
}
