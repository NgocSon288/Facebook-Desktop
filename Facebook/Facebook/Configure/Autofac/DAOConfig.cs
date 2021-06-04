using Autofac;
using Facebook.DAO;

namespace Facebook.Configure.Autofac
{
    public static class DAOConfig
    {
        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<UserDAO>().As<IUserDAO>().InstancePerLifetimeScope();
            builder.RegisterType<ProfileDAO>().As<IProfileDAO>().InstancePerLifetimeScope();
        }
    }
}