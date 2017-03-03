using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ebuy.Service;
using Ebuy.Service.Common;
using EbuyProject.Controllers;
using EbuyProject.ViewModels;

namespace EbuyProject
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ICarService>().To<CarService>();
            Kernel.Bind<IBookService>().To<BookService>();
            Kernel.Bind<ISportService>().To<SportService>();
            Kernel.Bind<IMusicService>().To<MusicService>();
            Kernel.Bind<ICartService>().To<CartService>();
            Kernel.Bind<IElectronicsService>().To<ElectronicsService>();
        }
    }
}