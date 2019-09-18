using AutoMapper;
using CarDealership.Dtos;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Car, CarDto>();
            Mapper.CreateMap<CarDto, Car>();

            Mapper.CreateMap<Dealer, DealerDto>();
            Mapper.CreateMap<DealerDto, Dealer>();

            Mapper.CreateMap<AvailabilityType, AvailabilityTypeDto>();
            Mapper.CreateMap<AvailabilityTypeDto, AvailabilityType>();



        }
    }
}