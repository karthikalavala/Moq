using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moq1.Code
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Create(CustomerToCreateDto customerToCreateDto)
        {
            var customer = BuildCustomerObjectFrom(customerToCreateDto);

            _customerRepository.Save(customer);
        }

        public void Create(IEnumerable<CustomerToCreateDto> customersToCreate)
        {
            foreach (var customerToCreateDto in customersToCreate)
            {
                _customerRepository.Save(
                    new Customer(
                        customerToCreateDto.City,
                        customerToCreateDto.Name)
                    );
            }
        }



        private Customer BuildCustomerObjectFrom(CustomerToCreateDto customerToCreateDto)
        {
            return new Customer(customerToCreateDto.Name, customerToCreateDto.City);
        }
    }
}
