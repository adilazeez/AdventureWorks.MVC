using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventureWorks.Service;


namespace AdventureWorks.App.Controllers
{
    public class ProductController : Controller
    {
        IProductionService productionService;

        public ProductController(IProductionService _productionService)
        {
            productionService = _productionService;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View(productionService.GetAllProductCategories());
        }
    }
}