using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventureWorks.EF.Views;
using AdventureWorks.Data.Repositories;
using AdventureWorks.Service;


namespace AdventureWorks.App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        IvEmployeeDepartmentRepos _employeeService;
        IvEmployeeRepos _employeesvc;
        int totrecs = 0;
        //List<vEmployee> _employeeList;
        //vEmployee _employee;

        public HomeController(IvEmployeeDepartmentRepos employeeServiceDI, IvEmployeeRepos employeeSvcDI)
        {
            _employeeService = employeeServiceDI;
            _employeesvc = employeeSvcDI;
            totrecs = _employeeService.NoOfEmployees;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EDirectory(string searchtext = "", string sortcolumn = "firstname", bool ascSort = true, int CurrPage = 1)
        {
            int recsPerPage = 10;
            int recsToSkip = ((CurrPage == 1) ? 0 : CurrPage-1) * recsPerPage;
            List<vEmployeeDepartment> _employeeListtoPage = new List<vEmployeeDepartment>();

            if (TempData["SearchString"] != null)
            {
                searchtext = TempData["SearchString"].ToString();
            }

            ViewBag.SortColumn = sortcolumn;
            ViewBag.AscSort = ascSort;
            ViewBag.NoOfPages = Math.Ceiling(Convert.ToDecimal(totrecs)/ recsPerPage);
            ViewBag.CurrentPage = CurrPage;
            ViewBag.NextPage = (CurrPage == ViewBag.NoOfPages) ? ViewBag.NoOfPages : (CurrPage + 1);
            ViewBag.PrevPage = (CurrPage > 1) ? (CurrPage - 1) : 1;
            ViewBag.SearchString = searchtext;

            _employeeListtoPage = ApplySortandFilter(searchtext, sortcolumn, ascSort, CurrPage, recsPerPage, recsToSkip);
            
            return View(_employeeListtoPage);
        }

        private List<vEmployeeDepartment> ApplySortandFilter(string searchText, string sortby, bool ascSort, int pageno, int takeCount, int skipCount)
        {
            List<vEmployeeDepartment> _retList = new List<vEmployeeDepartment>();

            if(ascSort == true)
            {
              switch(sortby)
                {
                    case "firstname" :
                        _retList = _employeeService.GetAllEmployeeList().OrderBy(x => x.FirstName).ToList();
                        break;
                    case "lastname":
                        _retList = _employeeService.GetAllEmployeeList().OrderBy(x => x.LastName).ToList();
                        break;
                    case "department":
                        _retList = _employeeService.GetAllEmployeeList().OrderBy(x => x.Department).ToList();
                        break;
                    case "groupname":
                        _retList = _employeeService.GetAllEmployeeList().OrderBy(x => x.GroupName).ToList();
                        break;
                    default:
                        break;
                }
            }
            else 
            {
                switch (sortby)
                {
                    case "firstname":
                        _retList = _employeeService.GetAllEmployeeList().OrderByDescending(x => x.FirstName).ToList();
                        break;
                    case "lastname":
                        _retList = _employeeService.GetAllEmployeeList().OrderByDescending(x => x.LastName).ToList();
                        break;
                    case "department":
                        _retList = _employeeService.GetAllEmployeeList().OrderByDescending(x => x.Department).ToList();
                        break;
                    case "groupname":
                        _retList = _employeeService.GetAllEmployeeList().OrderByDescending(x => x.GroupName).ToList();
                        break;
                    default:
                        break;
                }
            }

            if(searchText != "")
            {
                searchText = searchText.ToUpper();
                _retList = _retList.Where(t => (t.FirstName.ToUpper().Contains(searchText) || (t.LastName.ToUpper().Contains(searchText)))).ToList();
            }

            if (_retList.Count > takeCount)
            {
                _retList = _retList.Skip(skipCount).Take(takeCount).ToList();
            }

            return _retList;
        }

        
        public ActionResult EmployeeDetails(string employeeID)
        {
            vEmployee _emp = _employeesvc.GetEmployeeDetailsByID(Convert.ToInt32(employeeID));
            return PartialView(_emp);
        }

        public ActionResult EmployeeDeptDetails(string employeeID)
        {
            vEmployeeDepartment _empd = _employeeService.GetEmployeeDetailsByID(Convert.ToInt32(employeeID));
            return PartialView(_empd);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult EmployeeSearch(string stringSearch)
        {
            TempData["SearchString"] = stringSearch;
            return RedirectToAction("EDirectory", "Home");
        }
    }

}