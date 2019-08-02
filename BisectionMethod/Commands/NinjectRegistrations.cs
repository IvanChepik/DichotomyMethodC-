using Ninject.Modules;
using Services;
using Services.IServices;

namespace Commands
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IBisectionCalculator>().To<BisectionCalculator>().InSingletonScope();
        }
    }
}