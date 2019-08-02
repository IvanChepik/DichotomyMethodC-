using System;
using System.Windows.Forms;
using Ninject;
using Presenter;

namespace BisectionMethod
{
    public static class EntryPoint
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var registrations = new NinjectRegistration();
            var kernel = new StandardKernel(registrations);
            kernel.Get<MainPresenter>().Run();
            Application.Run(kernel.Get<ApplicationContext>());
        }
    }
}
