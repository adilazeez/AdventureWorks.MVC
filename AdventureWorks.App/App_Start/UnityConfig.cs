using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using AdventureWorks.Data.Repositories;
using AdventureWorks.Service;

namespace AdventureWorks.App
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IvEmployeeDepartmentRepos, EmployeeDepartmentService>();
            container.RegisterType<IvEmployeeRepos, EmployeeService>();
            container.RegisterType<IProductionService, ProductionService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}