using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.Data.Repositories;
using AdventureWorks.EF.Views;

namespace AdventureWorks.Service
{
    public class EmployeeDepartmentService : IvEmployeeDepartmentRepos
    {
        IvEmployeeDepartmentRepos empReference;

        public int NoOfEmployees { get; }

        public EmployeeDepartmentService()  
        {
            empReference = new vEmployeeDepartmentRepos();
            NoOfEmployees = empReference.NoOfEmployees;
        }

        public List<vEmployeeDepartment> GetAllEmployeeList()
        {
            return empReference.GetAllEmployeeList();
        }

        public vEmployeeDepartment GetEmployeeDetailsByID(int aEmployeeID)
        {
            return empReference.GetEmployeeDetailsByID(aEmployeeID);
        }

        public List<vEmployeeDepartment> GetEmployeeListFiltered(string aFilterCriteria)
        {
            return empReference.GetEmployeeListFiltered(aFilterCriteria);
        }
    }
}
