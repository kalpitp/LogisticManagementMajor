using AutoMapper;
using LogisticsManagement.DataAccess.Models;
using LogisticsManagement.DataAccess.Repository.IRepository;
using LogisticsManagement.Service.DTOs;
using LogisticsManagement.Service.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagement.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        public AuthService(IAuthRepository authRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }

   
        public async Task<int> SignUp(UserDTO user)
        {
            try
            {
                if (await _authRepository.GetUserByEmailId(user.Email) != null)
                {
                    return -1;
                }

                string hashedPassword = GenerateHashPassword(user.Password);


                User newUser = _mapper.Map<User>(user);
            
                UserDetail newUserDetail= _mapper.Map<UserDetail>(user);
                newUserDetail.User = newUser;

                //UserDetail? newUserDetail = null;
                //if (user.RoleId == 1)
                //{
                //    Console.WriteLine("Logic for admin");
                //}
                //else if (user.RoleId == 2)
                //{
                //    newUserDetail = new UserDetail()
                //    {
                //        User = newUser,
                //        WareHouseId = null,
                //        IsApproved = false
                //    };
                //}
                //else if (user.RoleId == 3)
                //{
                //    newUserDetail = new UserDetail()
                //    {
                //        User = newUser,
                //        LicenseNumber = user.LicenseNumber,
                //        WareHouseId = null,
                //        IsApproved = false

                //    };
                //}
                //else if (user.RoleId == 4)
                //{
                //    newUserDetail = new UserDetail()
                //    {

                //        User = newUser,
                //        WareHouseId = null,
                //        IsApproved = true,
                //    };
                //}
                //else
                //{
                //    return 0;
                //}

                return await _authRepository.AddUser(newUser, newUserDetail);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while adding user" + ex.Message);

            }
            return 0;
        }


        //Generate Hash of password 
        public string GenerateHashPassword(string password)
        {
            try
            {
                using (SHA512 sha512 = SHA512.Create())
                {
                    byte[] hashedBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
                    StringBuilder builder = new StringBuilder();
                    foreach (byte b in hashedBytes)
                    {
                        builder.Append(b.ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while Generating hash" + ex.Message);
                return null;
            }
        }
    }
}
