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
            //Domain to Dto(Data Transfer Object)
            Mapper.CreateMap<Car, CarDto>();
            Mapper.CreateMap<Dealer, DealerDto>();
            Mapper.CreateMap<AvailabilityType, AvailabilityTypeDto>();

            //Dto(Data Transfer Object) to Domain
            Mapper.CreateMap<CarDto, Car>()
                .ForMember(c => c.Id,opt =>opt.Ignore());            
            Mapper.CreateMap<DealerDto, Dealer>()
                .ForMember(c => c.Id, opt => opt.Ignore()); ;           



        }
    }
}