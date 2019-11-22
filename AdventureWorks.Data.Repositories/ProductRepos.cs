using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.EF.Data;

namespace AdventureWorks.Data.Repositories
{
    public interface IProductRepos
    {
        string GetHexStringProductThumbnail();
        string GetHexStringProductPhoto();
        List<ProductReview> GetReviewsforProduct();
        List<ProductVendor> GetPRoductVendorList();
    }

    public class ProductRepos : IProductRepos
    {
        AdventureWorksDataEntities awContext = new AdventureWorksDataEntities();
        Product product;
        ProductProductPhoto productPhotoRef;
        public ProductRepos(int productID)
        {
            product = (new AllProducts()).GetProduct(productID);
            productPhotoRef = awContext.ProductProductPhotoes.FirstOrDefault(t => t.ProductID == productID);
        }

        public string GetHexStringProductPhoto()
        {
            return productPhotoRef.ProductPhoto.LargePhoto.ToString() ;
        }

        public string GetHexStringProductThumbnail()
        {
            return productPhotoRef.ProductPhoto.ThumbNailPhoto.ToString();
        }

        public List<ProductVendor> GetPRoductVendorList()
        {
            return product.ProductVendors.ToList();
        }

        public List<ProductReview> GetReviewsforProduct()
        {
            return product.ProductReviews.ToList();
        }
    }
}
