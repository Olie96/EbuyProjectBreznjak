using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ebuy.DAL;
using Ebuy.Model;
using Ebuy.Model.Common;

namespace Ebuy.Repository
{
    public class RepositoryMappingConfig : Profile
    {
        public RepositoryMappingConfig()
        {
            CreateMap<Books, Book>().ReverseMap();
            CreateMap<Book, IBooks>().ReverseMap();
            CreateMap<Books, IBooks>().ReverseMap();
            CreateMap<Cars, Car>().ReverseMap();
            CreateMap<Cars, ICars>().ReverseMap();
            CreateMap<Car, ICars>().ReverseMap();
            CreateMap<Electronics, Electronic>().ReverseMap();
            CreateMap<Electronics, IElectronics>().ReverseMap();
            CreateMap<Electronic, IElectronics>().ReverseMap();
            CreateMap<Carts, Cart>().ReverseMap();
            CreateMap<Carts, ICart>().ReverseMap();
            CreateMap<Cart, ICart>().ReverseMap();
            CreateMap<Ebuy.Model.Music, Ebuy.DAL.Music>().ReverseMap();
            CreateMap<Ebuy.Model.Music, Ebuy.Model.Common.IMusic>().ReverseMap();
            CreateMap<Ebuy.DAL.Music, Ebuy.Model.Common.IMusic>().ReverseMap();
            CreateMap<Ebuy.Model.Sport, Ebuy.DAL.Sport>().ReverseMap();
            CreateMap<Ebuy.Model.Sport, Ebuy.Model.Common.ISport>().ReverseMap();
            CreateMap<Ebuy.DAL.Sport, Ebuy.Model.Common.ISport>().ReverseMap();
        }
    }
}
