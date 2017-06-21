using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moq1.Code
{
    public class CustomerService2
    {
        private readonly ICustomerAddressBuilder _customerAddressBuilder;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService2(ICustomerAddressBuilder customerAddressBuilder, ICustomerRepository customerRepository)
        {
            _customerAddressBuilder = customerAddressBuilder;
            _customerRepository = customerRepository;
        }
        public void Create(CustomerToCreateDto customerToCreate)
        {
            var customer = new Customer(
                customerToCreate.City,
                customerToCreate.Name);

            customer.MailingAddress = _customerAddressBuilder.From(customerToCreate);

            if (customer.MailingAddress == null)
            {
                throw new InvalidCustomerMailingAddressException();
            }

            _customerRepository.Save(customer);
        }
    }
}
