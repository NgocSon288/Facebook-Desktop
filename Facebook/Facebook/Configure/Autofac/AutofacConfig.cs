using Autofac;
using Facebook.DAO;
using Facebook.Data;
using Facebook.Data.Infrastructure;
using Facebook.Data.Repositories;
using Facebook.FormUC;
using Facebook.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Configure.Autofac
{
    public static class AutofacConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            // Config Infrastructures
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerLifetimeScope();

            // Config DBContext
            builder.RegisterType<FacebookDBContext>().AsSelf().InstancePerLifetimeScope();

            // Config Repositories
            RepositoryConfig.Configure(builder);

            //// Config Services
            ServiceConfig.Configure(builder);

            //// Config DAOs
            DAOConfig.Configure(builder);

            // Config Forms and UserControls
            FormConfig.Configure(builder);

            return builder.Build();
        }
    }
}
