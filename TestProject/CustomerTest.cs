using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Data;
using Entities;
using Moq;
using PL;
using NSubstitute;
using Xunit;

namespace TestProject
{
    public class CustomerTest
    {
        private CustomerService customerService;
        private Mock<IDataContext> mockContext= new Mock<IDataContext>(); 
        public CustomerTest()
        {
            customerService = new CustomerService();
        }

        public void CreateOrder_ShouldReturnTrue_WhenOrderHaveExistsProductId()
        {
            //Arrange
            var context = Substitute.For<IDataContext>();
            context.Orders.Returns(new List<OrderEntity>());
            UserEntity user = new UserEntity();
            var productId = int.Parse(Guid.NewGuid().ToString());
            //Act

            var result = customerService.CreateOrder(user, productId, context);
            //Assert

            Assert.True(result);
        }
    }
}
