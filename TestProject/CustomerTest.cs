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

        public void Task()
        {
            var context = Substitute.For<IDataContext>();
            context.Products.Returns(new List<ProductEntity>());
        }
    }
}
