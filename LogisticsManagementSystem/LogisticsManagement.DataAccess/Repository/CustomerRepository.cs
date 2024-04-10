using LogisticsManagement.DataAccess.Models;
using LogisticsManagement.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagement.DataAccess.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LogisticsManagementContext _dbContext;
        public CustomerRepository(LogisticsManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAddress(Address address)
        {
            try
            {
                UserDetail? userDetail = _dbContext.UserDetails.FirstOrDefault(u => u.Id == address.UserId);

                if (userDetail == null)
                {
                    return -2;
                }

                await _dbContext.Addresses.AddAsync(address);
                int result = await _dbContext.SaveChangesAsync();

                if (result == 0)
                {
                    return 0;
                }
                userDetail.Address = address;
                int userUpdated = await _dbContext.SaveChangesAsync();
               
                return userUpdated > 0 ? address.Id : 0;
                //return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding address: " + ex.Message);
                return -1;
            }
        }

        public async Task<Address?> GetAddressById(int AddressId)
        {
            try
            {

                if (AddressId > 0)
                {
                    Address? address = await _dbContext.Addresses.Include(w => w.City)
                                          .ThenInclude(w => w.State)
                                         .ThenInclude(w => w.Country)
                                         .FirstOrDefaultAsync(w => w.Id == AddressId);

                    if (address is not null)
                    {
                        return address;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while fetching address by id\n" + e.Message);
            }
            return null;
        }

        public async Task<List<Address>?> GetAllAddresses()
        {
            try
            {
                return await _dbContext.Addresses.Include(w => w.City)
                                                  .ThenInclude(w => w.State)
                                                  .ThenInclude(w => w.Country)
                                                  .ToListAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while fetching all addresses\n" + e.Message);
                return null;
            }
        }

        public async Task<int> UpdateAddress(Address address)
        {
            try
            {
                if (address is null)
                {
                    return 0;
                }


                Address? addressDetails = await _dbContext.Addresses.Where(w => w.Id == address.Id).FirstOrDefaultAsync();

                if (addressDetails is null)
                {
                    return 0;
                }

                //addressDetails.Address1 = address.Address1;
                //addressDetails.Pincode = address.Pincode;
                //addressDetails.CityId = address.CityId;
                //addressDetails.UpdatedAt = DateTime.Now;

                //_dbContext.Addresses.Update(addressDetails);
                
                _dbContext.Addresses.Attach(address);

                _dbContext.Entry(address).State= EntityState.Modified;
                int result = await _dbContext.SaveChangesAsync();
                return result > 0 ? address.Id : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating address: " + ex.Message);
                return -1;
            }
        }


        public async Task<int> RemoveAddress(int addressId)
        {
            try
            {
                Address? address = await _dbContext.Addresses.FirstOrDefaultAsync(w => w.Id == addressId && w.IsActive == true);

                if (address != null)
                {
                    address.IsActive = false;
                    address.UpdatedAt = DateTime.Now;
                    address.UserDetails.FirstOrDefault().AddressId = null;
                    int result = await _dbContext.SaveChangesAsync();

                    //if (result > 0)
                    //{
                    //    UserDetail? userDetail = _dbContext.UserDetails.FirstOrDefault(u => u.Id == address.UserId);

                    //    if (userDetail == null)
                    //    {
                    //        return -2;
                    //    }
                    //    userDetail.AddressId = null;
                    //}
                    return result > 0 ? address.Id : 0;

                }
                return 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting address: " + ex.Message);
                return -1;
            }
        }
    }
}
