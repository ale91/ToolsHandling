using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Services;

namespace ToolsWebAPI.App_Start
{
    public class ContainerConfig
    {
        static IContainer _container;

        public static IContainer Build()
        {
            var containerBuilder = new ContainerBuilder();

            var assemblies = new Assembly[]
            {
                typeof(ContainerConfig).Assembly,
                typeof(IService).Assembly,

            };

            containerBuilder.RegisterAssemblyTypes(assemblies) 
            .AsImplementedInterfaces();



            containerBuilder.RegisterApiControllers(assemblies);

            containerBuilder.RegisterControllers(assemblies);



            _container = containerBuilder.Build();


            return _container;
        }
    }
}