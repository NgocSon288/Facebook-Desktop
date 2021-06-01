using Autofac;
using Facebook.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Configure.Autofac
{
    public static class DAOConfig
    {
        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<UserDAO>().As<IUserDAO>().InstancePerLifetimeScope();
        }
    }
}
