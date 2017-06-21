using Moq;
using Moq1.Code;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moq1.tests
{
    public class CustomerServiceTest2
    {
        [TestFixture]
        public class When_creating_multiple_customers
        {
            //shows how to verify that a method was called an explicit number of times
            [Test]
            public void the_customer_repository_should_be_called_once_per_customer()
            {
                //Arrange
                var listOfCustomerDtos = new List<CustomerToCreateDto>
                    {
                        new CustomerToCreateDto { City = "LA", Name = "A" },
                        new CustomerToCreateDto { City = "LB", Name = "B" },
                        new CustomerToCreateDto { City = "LC", Name = "C" }
                    };

                var mockCustomerRepository = new Mock<ICustomerRepository>();

                var customerService = new CustomerService(mockCustomerRepository.Object);
                //Act
                customerService.Create(listOfCustomerDtos);

                //Assert
                mockCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()),
                    Times.Exactly(listOfCustomerDtos.Count));
            }
        }
    }
}
