using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.EF.Data;

namespace AdventureWorks.Data.Repositories
{
    public interface IProductCategoriesRepos
    {
        int NoOfCategories { get; }
        List<AdventureWorks.EF.Data.ProductSubcategory> GetSubCategoriesForCategoryByID(int categoryID);
        List<AdventureWorks.EF.Data.ProductCategory> GetAllProductCategories();
    }

    public class ProductCategoriesRepos : IProductCategoriesRepos
    {
        AdventureWorks.EF.Data.AdventureWorksDataEntities awContext = new AdventureWorks.EF.Data.AdventureWorksDataEntities();
        List<AdventureWorks.EF.Data.ProductCategory> productCategories;

        public ProductCategoriesRepos()
        {
            productCategories = awContext.ProductCategories.ToList();
            NoOfCategories = productCategories.Count;
        }

        public int NoOfCategories { get; }

        public List<ProductCategory> GetAllProductCategories()
        {
            return productCategories;
        }

        public List<ProductSubcategory> GetSubCategoriesForCategoryByID(int categoryID)
        {
            return (new ProductSubCategoriesRepos(categoryID)).GetAllSubCategoriesForCategory();
        }
    }
}
