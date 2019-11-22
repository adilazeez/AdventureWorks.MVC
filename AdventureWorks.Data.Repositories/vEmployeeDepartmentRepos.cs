using AdventureWorks.EF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Repositories
{
    public interface IvEmployeeDepartmentRepos
    {
        List<vEmployeeDepartment> GetAllEmployeeList();
        List<vEmployeeDepartment> GetEmployeeListFiltered(string aFilterCriteria);
        vEmployeeDepartment GetEmployeeDetailsByID(int aEmployeeID);
        int NoOfEmployees { get; }
    }

    public class vEmployeeDepartmentRepos : IvEmployeeDepartmentRepos
    {
        AdventureWorks.EF.Views.AdventureWorksViewsEntities awContext = new AdventureWorks.EF.Views.AdventureWorksViewsEntities();
        List<vEmployeeDepartment> rEmployeeList;

        public vEmployeeDepartmentRepos()
        {
            rEmployeeList = awContext.vEmployeeDepartments.ToList();
            NoOfEmployees = rEmployeeList.Count;
        }

        public int NoOfEmployees { get; }

        public List<vEmployeeDepartment> GetAllEmployeeList()
        {
            return rEmployeeList;
        }

        public vEmployeeDepartment GetEmployeeDetailsByID(int aEmployeeID)
        {
            return rEmployeeList.FirstOrDefault(t => t.BusinessEntityID == aEmployeeID);
        }

        public List<vEmployeeDepartment> GetEmployeeListFiltered(string aFilterCriteria)
        {
            //return rEmployeeList.FindAll(t => t.FirstName.Contains(aFilterCriteria) == true);
            return rEmployeeList.Where(t => t.FirstName.Contains(aFilterCriteria) == true).ToList<vEmployeeDepartment>();
        }
    }
}
