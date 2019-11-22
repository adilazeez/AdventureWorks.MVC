using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.Data.Repositories;
using AdventureWorks.EF.Views;

namespace AdventureWorks.Service
{
    public class EmployeeService : IvEmployeeRepos
    {
        IvEmployeeRepos empReference;

        public EmployeeService()
        {
            empReference = new vEmployeeRepos();
        }

        public List<vEmployee> GetAllEmployeeList()
        {
            return empReference.GetAllEmployeeList();
        }

        public vEmployee GetEmployeeDetailsByID(int aEmployeeID)
        {
            return empReference.GetEmployeeDetailsByID(aEmployeeID);
        }

        public List<vEmployee> GetEmployeeListFiltered(string aFilterCriteria)
        {
            return empReference.GetEmployeeListFiltered(aFilterCriteria);
        }
    }
}
