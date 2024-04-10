using AutoMapper;
using LogisticsManagement.DataAccess.Models;
using LogisticsManagement.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogisticsManagement.Service.Convertors
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            try
            {

                CreateMap<User, UserDTO>()
                    .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.UserDetails.FirstOrDefault().AddressId))
                    .ForMember(dest => dest.LicenseNumber, opt => opt.MapFrom(src => src.UserDetails.FirstOrDefault().LicenseNumber))
                    .ForMember(dest => dest.WareHouseId, opt => opt.MapFrom(src => src.UserDetails.FirstOrDefault().WareHouseId))
                    .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.UserDetails.FirstOrDefault().IsAvailable))
                    .ForMember(dest => dest.IsApproved, opt => opt.MapFrom(src => src.UserDetails.FirstOrDefault().IsApproved))
                    .ReverseMap();
                CreateMap<UserDetail, UserDTO>().ReverseMap();

                CreateMap<Warehouse, WarehouseDTO>()
                     .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name))
                     .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.City.State.Name))
                     .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.City.State.Country.Name));


                CreateMap<WarehouseDTO, Warehouse>();


                CreateMap<Address, AddressDTO>()
                     .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name))
                     .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.City.State.Name))
                     .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.City.State.Country.Name))
                    .ReverseMap();

                CreateMap<Address, Address>().ForMember(dest => dest.Id, opt => opt.Ignore());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
