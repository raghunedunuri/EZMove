using EzMove.Business;
using EzMove.DataAccess.Repositories.Implementors;
using EzMove.DataAccess.Repositories.Interfaces;
using EzMove.DataAcess;
using EzMove.DataAcess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace EzMove
{
    public static class Bootstrapper
    {
        public static IUnityContainer Container { get; set; }
        public static IUnityContainer Initialise()
        {
            Container = BuildUnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(Container);
            return Container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IConnectionManager, MySqlConnectionManager>(new ContainerControlledLifetimeManager());
            container.RegisterType<IDbHelper, MySqlDbHelper>(new ContainerControlledLifetimeManager());

            container.RegisterType<IDashboardService, DashboardService>();
            container.RegisterType<IDriverService, DriverService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<IShiftService, ShiftService>();
            container.RegisterType<ITripService, TripService>();

            container.RegisterType<IDashboardRepository, DashboardRepository>();
            container.RegisterType<IDriverRepository, DriverRepository>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<ILoginRepository, LoginRepository>();
            container.RegisterType<IShiftRepository, ShiftRepository>();
            container.RegisterType<ITripRepository, TripRepository>();
        }
    }
}