using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Features.Images.Commands;
using Domain.Models.Images;
using Domain.Models.Locations;
using Application.Features.Locations.Queries.All;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateImageCommand, Image>();

            CreateMap<CreateLocationCommand, Location>();
            CreateMap<UpdateLocationCommand, Location>();
            CreateMap<GetLocationsQuery, GetLocationsParameter>();
            CreateMap<Location, GetLocationsViewModel>().ReverseMap();
        }
    }
}
