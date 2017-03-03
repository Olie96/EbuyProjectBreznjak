using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;
using Ebuy.Repository;
using Ebuy.Repository.Common;

namespace Ebuy.Service
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ICarRepository>().To<CarRepository>();
            Kernel.Bind<ICartsRepository>().To<CartRepository>();
            Kernel.Bind<IMusicRepository>().To<MusicRepository>();
            Kernel.Bind<ISportRepository>().To<SportRepository>();
            Kernel.Bind<IBookRepository>().To<BookRepository>();
            Kernel.Bind<IElectronicsRepository>().To<ElectronicsRepository>();

            Kernel.Bind<IRepository<Book>>().To<GenericRepository<Book>>();
            Kernel.Bind<IRepository<Sport>>().To<GenericRepository<Sport>>();
            Kernel.Bind<IRepository<Electronic>>().To<GenericRepository<Electronic>>();
            Kernel.Bind<IRepository<Music>>().To<GenericRepository<Music>>();
            Kernel.Bind<IRepository<Car>>().To<GenericRepository<Car>>();
            Kernel.Bind<IRepository<Cart>>().To<GenericRepository<Cart>>();
        }
    }
}
