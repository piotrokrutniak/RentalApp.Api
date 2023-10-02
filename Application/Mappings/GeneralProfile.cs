using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Features.Images.Commands;
using Domain.Models.Images;


namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateImageCommand, Image>();
        }
    }
}
