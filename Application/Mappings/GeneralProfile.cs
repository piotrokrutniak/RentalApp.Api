using AutoMapper;
using Domain.Models.Locations;
using Application.Features.Locations.Queries.All;
using Domain.Models.Vehicles;
using Application.Features.Vehicles.Queries.All;
using Application.Features.Reservations.Queries.All;
using Domain.Models.Reservations;
using Application.Features.Vehicles.Commands.Create;
using Application.Features.Vehicles.Commands.Update;
using Application.Features.Locations.Commands.Create;
using Application.Features.Locations.Commands.Update;
using Application.Features.Reservations.Commands.Create;
using Application.Features.Reservations.Commands.Update;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateVehicleCommand, Vehicle>();
            CreateMap<UpdateVehicleByIdCommand, Vehicle>();
            CreateMap<GetVehicleQuery, GetVehicleParameter>();
            CreateMap<Vehicle, GetVehicleViewModel>().ReverseMap();

            CreateMap<CreateReservationCommand, Reservation>();
            CreateMap<UpdateReservationByIdCommand, Reservation>();
            CreateMap<GetReservationQuery, GetReservationParameter>();
            CreateMap<Reservation, GetReservationViewModel>().ReverseMap();

            CreateMap<CreateLocationCommand, Location>();
            CreateMap<UpdateLocationCommand, Location>();
            CreateMap<GetLocationsQuery, GetLocationsParameter>();
            CreateMap<Location, GetLocationsViewModel>().ReverseMap();
        }
    }
}
