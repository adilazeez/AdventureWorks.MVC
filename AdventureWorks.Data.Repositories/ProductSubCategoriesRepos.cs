using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.EF.Data;

namespace AdventureWorks.Data.Repositories
{
    public interface IProductSubCategoriesRepos
    {
        int NoOfProducts { get; }
        List<AdventureWorks.EF.Data.ProductSubcategory> GetAllSubCategoriesForCategory();
        List<AdventureWorks.EF.Data.Product> GetProductsinSubCategoryByID(int subcategoryID);
    }

    public class ProductSubCategoriesRepos : IProductSubCategoriesRepos
    {
        AdventureWorks.EF.Data.AdventureWorksDataEntities awContext = new AdventureWorksDataEntities();
        List<AdventureWorks.EF.Data.ProductSubcategory> productSubCategories;
        AdventureWorks.Data.Repositories.ProductsRepos productsRepos;

        public ProductSubCategoriesRepos(int categoryID)
        {
            productSubCategories = awContext.ProductSubcategories.Where(t => t.ProductCategoryID == categoryID).ToList();
            NoOfProducts = productSubCategories.Count;
        }

        public int NoOfProducts { get; }

        public List<ProductSubcategory> GetAllSubCategoriesForCategory()
        {
            return productSubCategories;
        }

        public List<Product> GetProductsinSubCategoryByID(int subcategoryID)
        {
            return (new ProductsRepos(subcategoryID)).GetAllProductsForSubCategory();
        }
    }
}
