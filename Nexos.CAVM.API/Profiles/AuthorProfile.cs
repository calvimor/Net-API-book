using AutoMapper;
using Nexos.CAVM.API.Entities;
using Nexos.CAVM.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Profiles
{
    public class AuthorProfile: Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>();

            CreateMap<AuthorDto, Author>();

            CreateMap<AuthorForCreationDto, Author>();
        }
    }
}
