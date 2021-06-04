using Autofac;
using Facebook.Components.Profile;
using Facebook.FormUC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Configure.Autofac
{
    public static class FormConfig
    {
        public static void Configure(ContainerBuilder builder)
        {
            // Forms
            builder.RegisterType<fMain>().InstancePerLifetimeScope();
            builder.RegisterType<fAccountForm>().InstancePerLifetimeScope();

            // User controls
            builder.RegisterType<fLogin>().InstancePerLifetimeScope();

            // Components
            builder.RegisterType<InfoProfileUC>().InstancePerLifetimeScope();
        }
    }
}
