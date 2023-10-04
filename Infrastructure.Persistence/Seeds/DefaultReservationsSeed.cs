﻿using Application.Interfaces;
using Domain.Common;
using Domain.Interfaces;
using Domain.Models.Locations;
using Domain.Models.Reservations;
using Domain.Models.Vehicles;
using Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public class DefaultReservationsSeed
    {
        public static async Task SeedAsync(IGenericRepositoryAsync<Reservation> reservationRepositoryAsync, IGenericRepositoryAsync<Vehicle> vehicleRepositoryAsync)
        {
            List<Reservation> reservations = new()
            {
                new Reservation
                {
                    VehicleId = 1,
                    Email = "greg@gmail.com",
                    Phone = "+48 152 682 193",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5),
                },
                new Reservation
                {
                    VehicleId = 1,
                    Email = "joe@gmail.com",
                    Phone = "+44 192 023 912",
                    StartDate = DateTime.Now.AddDays(6),
                    EndDate = DateTime.Now.AddDays(14),
                },
                new Reservation
                {
                    VehicleId = 2,
                    Email = "",
                    Phone = "",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14),
                },
                new Reservation
                {
                    VehicleId = 4,
                    Email = "",
                    Phone = "",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14),
                },
                new Reservation
                {
                    VehicleId = 5,
                    Email = "",
                    Phone = "",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14),
                },

            };

            foreach (Reservation reservation in reservations)
            {
                Vehicle vehicle = await vehicleRepositoryAsync.GetByIdAsync(reservation.VehicleId);
                reservation.UpdateFee(vehicle);

                await reservationRepositoryAsync.AddAsync(reservation);
            }
        }
    }
}


/*public Reservation() { }
public Vehicle Vehicle { get; set; }
public int VehicleId { get; set; }
[EmailAddress]
public string Email { get; set; }
[Phone]
public string Phone { get; set; }
public decimal Fee { get; private set; }
public DateTime StartDate { get; set; }
public DateTime EndDate { get; set; }*/