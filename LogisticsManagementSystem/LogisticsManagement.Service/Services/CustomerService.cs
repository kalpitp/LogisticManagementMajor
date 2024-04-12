using AutoMapper;
using LogisticsManagement.DataAccess.Models;
using LogisticsManagement.DataAccess.Repository;
using LogisticsManagement.DataAccess.Repository.IRepository;
using LogisticsManagement.Service.DTOs;
using LogisticsManagement.Service.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagement.Service.Services
{
    public class CustomerService:ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper) {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<AddressDTO>?> GetAllAddressAsync()
        {
            try
            {
                List<Address>? addresses = await _customerRepository.GetAllAddresses();

                if (addresses is null || addresses.Count == 0)
                {
                    return [];
                }

                return _mapper.Map<List<AddressDTO>>(addresses);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while getting all addresses" + ex.Message);
                return null;
            }
        }
        public async Task<int> AddAddressAsync(AddressDTO address)
        {
            try
            {
                if (address == null)
                    return -1;
                Address newAddress = _mapper.Map<Address>(address);

                int addedAddressId = await _customerRepository.AddAddress(newAddress);

                return addedAddressId;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while adding Address" + ex.Message);
                return -1;
            }
        }

        public async Task<AddressDTO?> GetAddressByIdAsync(int addressId)
        {
            try
            {
                if (addressId <= 0)
                {
                    return null;
                }
                Address? address = await _customerRepository.GetAddressById(addressId);

                if (address is null)
                { return null; }

                return _mapper.Map<AddressDTO>(address);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while fetching address " + ex.Message);
                return null;
            }
        }

   

        public async Task<int> RemoveAddressAsync(int addressId)
        {
            try
            {
                if (addressId <= 0)
                {
                    return -1;
                }
                int deletedAddressId = await _customerRepository.RemoveAddress(addressId);
                return deletedAddressId;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while removing address" + ex.Message);
                return -1;
            }
        }

        public async Task<int> UpdateAddressAsync(AddressDTO address)
        {
            try
            {
                if (address == null)
                    return -1;

                Address updatedAddress = _mapper.Map<Address>(address);
                updatedAddress.UpdatedAt = DateTime.Now;
                
                int updatedAddressId = await _customerRepository.UpdateAddress(updatedAddress);

                return updatedAddressId;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while updating address" + ex.Message);
                return -1;
            }
        }

        public async Task<List<OrderDTO>?> ViewOrderDetails(int orderId)
        {
            try
            {
                List<OrderDetail> orderDetails = await _customerRepository.GetAllOrderDetails(orderId);

                if (orderDetails is null || orderDetails.Count == 0)
                {
                    return null;
                }

                return _mapper.Map<List<OrderDTO>>(orderDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while fetching the order details. " + ex.Message);
                return null;
            }
        }
    }
}
