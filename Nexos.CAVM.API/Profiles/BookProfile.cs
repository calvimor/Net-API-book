using AutoMapper;
using Nexos.CAVM.API.Entities;
using Nexos.CAVM.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Profiles
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
            .ForMember(
                    dest => dest.Publisher,
                    opt => opt.MapFrom(src => $"{src.Publisher.PublisherName}"))
            .ForMember(
                dest => dest.Author,
                opt => opt.MapFrom(src => src.Author.Name))
            ;

            CreateMap<BookForCreationDto, Book>();
        }
    }
}
