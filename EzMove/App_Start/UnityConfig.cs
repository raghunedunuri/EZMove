using EzMove.Business;
using EzMove.DataAccess.Repositories.Implementors;
using EzMove.DataAccess.Repositories.Interfaces;
using EzMove.DataAcess;
using EzMove.DataAcess.Repositories;
using System;

using Unity;
using Unity.Lifetime;

namespace EzMove
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
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