using System.Windows.Forms;
using Ninject.Modules;
using Presenter;
using Views.IViews;
using Views.Views;

namespace BisectionMethod
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<ApplicationContext>().ToConstant(new ApplicationContext());
            Bind<IMainView>().To<MainView>();
            Bind<MainPresenter>().ToSelf();
        }
    }
}