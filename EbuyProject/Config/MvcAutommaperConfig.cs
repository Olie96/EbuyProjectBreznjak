using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ebuy.DAL;
using Ebuy.Model;
using Ebuy.Model.Common;
using EbuyProject.ViewModels;
using Ebuy.Repository;
using EbuyProject.Controllers;

namespace EbuyProject
{
    public class MvcAutommaperConfig : Profile
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.AddProfile<RepositoryMappingConfig>();
                config.CreateMap<CarViewModel, ICars>().ReverseMap();
                config.CreateMap<BookViewModel, IBooks>().ReverseMap();
                config.CreateMap<SportViewModel, ISport>().ReverseMap();
                config.CreateMap<MusicViewModel, IMusic>().ReverseMap();
                config.CreateMap<ElectronicsViewModel, IElectronics>().ReverseMap();
                config.CreateMap<CartViewModel, ICart>().ReverseMap();
            });

        }
    }
}
