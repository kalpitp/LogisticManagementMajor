using LogisticsManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagement.DataAccess.Repository.IRepository
{
    public interface ICustomerRepository
    {
        Task<List<Address>?> GetAllAddresses(); // Get all Addresss
        Task<Address?> GetAddressById(int AddressId); // Get Address by id
        Task<int> AddAddress(Address address); // Add Address
        Task<int> UpdateAddress(Address address); // Update Address

        Task<int> RemoveAddress(int addressId); // Remove Address
    }
}
