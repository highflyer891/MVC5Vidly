using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;
namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Customers, CustomerDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<Genre, GenreTypeDto>();


            //DTO to domain
            Mapper.CreateMap<CustomerDto, Customers>();
            Mapper.CreateMap<MovieDto, Movie>();
            
        }
    }
}