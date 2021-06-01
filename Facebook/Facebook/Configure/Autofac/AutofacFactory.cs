using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Configure.Autofac
{
    public static class AutofacFactory<T>
    {
        public static T Get()
        {
            return Program.Container.Resolve<T>();
        }
    }
}
