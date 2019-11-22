using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.Data.Repositories;
using AdventureWorks.EF.Data;

namespace AdventureWorks.Service
{
    public interface IProductionService
    {
        List<AdventureWorks.EF.Data.ProductCategory> GetAllProductCategories();
        List<AdventureWorks.EF.Data.ProductSubcategory> GetAllProductSubCategories(int categoryID);
        List<AdventureWorks.EF.Data.Product> GetAllProductsForSubCategory(int subcategoryID);
    }

    public class ProductionService : IProductionService
    {
        IProductCategoriesRepos pcRepos;

        public ProductionService()
        {
            pcRepos = new ProductCategoriesRepos();
        }

        public List<ProductCategory> GetAllProductCategories()
        {
            return pcRepos.GetAllProductCategories();
        }

        public List<Product> GetAllProductsForSubCategory(int subcategoryID)
        {
            return new ProductsRepos(subcategoryID).GetAllProductsForSubCategory();
        }

        public List<ProductSubcategory> GetAllProductSubCategories(int categoryID)
        {
            return pcRepos.GetSubCategoriesForCategoryByID(categoryID);
        }
    }
}
