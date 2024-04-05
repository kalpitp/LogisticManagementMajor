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
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<UserDetail,UserDTO>().ReverseMap();
        }
    }
}
