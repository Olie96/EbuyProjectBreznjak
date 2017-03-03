using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;

namespace Ebuy.Repository
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IMyDbContext>().To<MyDbContext>().InSingletonScope();
        }
    }
}
