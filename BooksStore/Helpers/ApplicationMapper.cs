using AutoMapper;
using BooksStore.DTO;
using BooksStore.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Models.Book, Book>().ReverseMap()
                .ForMember(x => x.Id, opt => opt.MapFrom(scr => scr.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(scr => scr.Name))
                .ForMember(x => x.Category, opt => opt.MapFrom(scr => scr.Category.Name))
                .ForMember(x => x.Author, opt => opt.MapFrom(scr => scr.Author.Name))
                .ForMember(x => x.Publisher, opt => opt.MapFrom(scr => scr.Publisher.Name))
                .ForMember(x => x.Image, opt => opt.MapFrom(scr => scr.Image))
                .ForMember(x => x.Description, opt => opt.MapFrom(scr => scr.Description))
                .ForMember(x => x.Price, opt => opt.MapFrom(scr => scr.Price));
            CreateMap<Book, Models.Book>().ReverseMap()
                .ForMember(x => x.Id, opt => opt.MapFrom(scr => scr.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(scr => scr.Name))
                .ForMember(x => x.Category, opt => opt.MapFrom(scr => scr.Category))
                .ForMember(x => x.Author, opt => opt.MapFrom(scr => scr.Author))
                .ForMember(x => x.Publisher, opt => opt.MapFrom(scr => scr.Publisher))
                .ForMember(x => x.Image, opt => opt.MapFrom(scr => scr.Image))
                .ForMember(x => x.Description, opt => opt.MapFrom(scr => scr.Description))
                .ForMember(x => x.Price, opt => opt.MapFrom(scr => scr.Price));

            CreateMap<Models.Category, Category>().ReverseMap();
            CreateMap<Category, Models.Category>().ReverseMap();




            CreateMap<Models.Author, Author>().ReverseMap();
            CreateMap<Author, Models.Author>().ReverseMap();


            CreateMap<Models.Publisher, Publisher>().ReverseMap();
            CreateMap<Publisher, Models.Publisher>().ReverseMap();

            
        }
    }
}
