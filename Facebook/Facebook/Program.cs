using Autofac;
using Facebook.Configure;
using Facebook.Configure.Autofac;
using Facebook.DAO;
using Facebook.Data;
using Facebook.Data.Infrastructure;
using Facebook.Data.Repositories;
using Facebook.FormUC;
using Facebook.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook
{
    public static class Program
    {
        public static IContainer Container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Container = AutofacConfig.Configure();

            Application.Run(new fMain());

        }

    }
}

