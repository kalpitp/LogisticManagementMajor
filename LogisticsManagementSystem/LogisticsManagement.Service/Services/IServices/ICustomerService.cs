using LogisticsManagement.DataAccess.Models;
using LogisticsManagement.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagement.Service.Services.IServices
{
    public interface ICustomerService
    {
        Task<List<AddressDTO>?> GetAllAddressAsync(); // Get all Addresses
        Task<AddressDTO?> GetAddressByIdAsync(int addressId); // Get Address by id
        Task<int> AddAddressAsync(AddressDTO address); // Add Address

        Task<int> UpdateAddressAsync(AddressDTO address); // Update Address


        Task<int> RemoveAddressAsync(int addressId); // Remove Address

    }
}
