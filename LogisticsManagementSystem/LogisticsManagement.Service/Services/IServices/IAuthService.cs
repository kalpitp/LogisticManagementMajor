using LogisticsManagement.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagement.Service.Services.IServices
{
    public interface IAuthService
    {
        Task<int> SignUp(UserDTO user);
        string GenerateHashPassword(string password);
    }
}
