using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.EF.Views;

namespace AdventureWorks.Data.Repositories
{
    
    public interface IvEmployeeRepos
    {
        List<vEmployee> GetAllEmployeeList();
        List<vEmployee> GetEmployeeListFiltered(string aFilterCriteria);
        vEmployee GetEmployeeDetailsByID(int aEmployeeID);
    }

    public class vEmployeeRepos : IvEmployeeRepos
    {

        AdventureWorksViewsEntities awContext = new AdventureWorksViewsEntities();
        List<vEmployee> rEmployeeList;

        public vEmployeeRepos()
        {
            rEmployeeList = awContext.vEmployees.ToList();
        }

        public List<vEmployee> GetAllEmployeeList()
        {
            return rEmployeeList;
        }

        public vEmployee GetEmployeeDetailsByID(int aEmployeeID)
        {
            return rEmployeeList.FirstOrDefault(t => t.BusinessEntityID == aEmployeeID);
        }

        public List<vEmployee> GetEmployeeListFiltered(string aFilterCriteria)
        {
            //return rEmployeeList.FindAll(t => t.FirstName.Contains(aFilterCriteria) == true);
            return rEmployeeList.Where(t => t.FirstName.Contains(aFilterCriteria) == true).ToList<vEmployee>();
        }
    }
}
