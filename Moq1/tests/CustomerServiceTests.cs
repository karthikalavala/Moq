using Moq;
using Moq1.Code;
using NUnit.Framework;

namespace Moq1.tests
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_customer
        {
            // arrange, act, assert pattern
            [Test]
            public void the_repository_save_should_be_called()
            {
                //arrange
                var mockRepository = new Mock<ICustomerRepository>();

                //we expect repo.save to be executed with any customer obj being passed
                mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));

                var customerService = new CustomerService(mockRepository.Object);

                //act
                customerService.Create(new CustomerToCreateDto());

                //assert - check to see if everything that was setup in arrange was occured
                mockRepository.VerifyAll();
            }            
        }
    }
}