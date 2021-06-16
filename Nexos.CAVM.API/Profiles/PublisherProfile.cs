using AutoMapper;
using Nexos.CAVM.API.Entities;
using Nexos.CAVM.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Profiles
{
    public class PublisherProfile:Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherDto>();

            CreateMap<PublisherDto, Publisher>();

            CreateMap<PublisherForCreationDto, Publisher>();
        }
    }
}
