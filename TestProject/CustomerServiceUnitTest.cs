using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using Domain;
using BLL;
using NSubstitute;
/*
namespace TestProject
{
    [TestClass]
    public class CustomerServiceUnitTest
    {
        private readonly CustomerService customerService;
                
        public CustomerServiceUnitTest()
        {
            customerService = new CustomerService();
        }

        [TestMethod]
        public void CreateOrder_ShouldCreateOrder_WhenOrderHaveExistsProductIdAndCustomerId()
        {
            //Arrange
            var context = Substitute.For<IRepository>();
            ProductEntity product = new ProductEntity()
            {
                Id = 1,
                Name = "test name",
                Category = "test category",
                Price = 1.11M
            };
            List<ProductEntity> products = new List<ProductEntity>();
            products.Add(product);

            CustomerEntity user = new CustomerEntity()
            {
                Id = 1,
                Name = "test name",
                Surname = "test surname",
                DateOfBirth = new DateTime(),
                Email = "test email",
                Password = "testpass"
            };
            List<CustomerEntity> users = new List<CustomerEntity>();
            users.Add(user);

            context.GetAllOrders().Returns(new List<OrderEntity>());
            context.Products.Returns(products);
            context.Customers.Returns(users);

            //Act
            var result = customerService.CreateOrder(user.Id, product.Id, context);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, context.Orders.Count);
        }

        [TestMethod]
        public void CreateOrder_ShouldNotCreateOrder_WhenOrderHaveNoExistsProductIdAndExistsCustomerId()
        {
            //Arrange
            var context = Substitute.For<IRepository>();
            CustomerEntity user = new CustomerEntity()
            {
                Id = 1,
                Name = "test name",
                Surname = "test surname",
                DateOfBirth = new DateTime(),
                Email = "test email",
                Password = "testpass"
            };
            List<CustomerEntity> users = new List<CustomerEntity>();
            users.Add(user);
            context.Customers.Returns(users);
            context.Orders.Returns(new List<OrderEntity>());
            context.Products.Returns(new List<ProductEntity>());
            

            //Act
            var result = customerService.CreateOrder(user.Id, 1, context);

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0, context.Orders.Count);
        }

        [TestMethod]
        public void CreateOrder_ShouldNotCreateOrder_WhenOrderHaveExistsProductIdAndNoExistsCustomer()
        {
            //Arrange
            var context = Substitute.For<IRepository>();
            ProductEntity product = new ProductEntity()
            {
                Id = 1,
                Name = "test name",
                Category = "test category",
                Price = 1.11M
            };
            List<ProductEntity> products = new List<ProductEntity>();
            products.Add(product);
            context.Orders.Returns(new List<OrderEntity>());
            context.Products.Returns(products);
            context.Customers.Returns(new List<CustomerEntity>());

            //Act
            var result = customerService.CreateOrder(1, product.Id, context);

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0, context.Orders.Count);
        }

        [TestMethod]
        public void GetAllCustomerOrders_ShouldReturnOrders_WhenCustomerHaveOrder()
        {
            //Arrange
            var context = Substitute.For<IRepository>();

            CustomerEntity user = new CustomerEntity()
            {
                Id = 1,
                Name = "test name",
                Surname = "test surname",
                DateOfBirth = new DateTime(),
                Email = "test email",
                Password = "testpass"
            };

            OrderEntity order = new OrderEntity()
            {
                Id = 1,
                Customer = user,
                Product = new ProductEntity(),
                State = OrderState.New
            };
            List<OrderEntity> orders = new List<OrderEntity>();
            orders.Add(order);
            context.Orders.Returns(orders);

            //Act
            var result = customerService.GetAllCustomerOrders(user.Id, context);

            //Assert
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void GetAllCustomerOrders_ShouldNotReturnOrders_WhenCustomerDoesNotHaveOrder()
        {
            //Arrange
            var context = Substitute.For<IRepository>();
            context.Orders.Returns(new List<OrderEntity>());

            //Act
            var result = customerService.GetAllCustomerOrders(1, context);

            //Assert
            Assert.AreEqual(0, result.Count());
        }


        [TestMethod]
        public void UpdateOrderStateAsReceived_ShouldUpdateOrderStateAsReceived_WhenCustomerOrderExistAndCanBeReceived()
        {
            //Arrange
            var context = Substitute.For<IRepository>();

            CustomerEntity user = new CustomerEntity()
            {
                Id = 1,
                Name = "test name",
                Surname = "test surname",
                DateOfBirth = new DateTime(),
                Email = "test email",
                Password = "testpass"
            };

            OrderEntity order = new OrderEntity()
            {
                Id = 1,
                Customer = user,
                Product = new ProductEntity(),
                State = OrderState.New
            };
            List<OrderEntity> orders = new List<OrderEntity>();
            orders.Add(order);
            context.Orders.Returns(orders);

            //Act
            var result = customerService.UpdateOrderStateAsReceived(order.Id, user.Id, context);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(context.Orders.First(o => o.Id == order.Id).State, OrderState.Received);
        }

        [TestMethod]
        public void UpdateOrderStateAsReceived_ShouldNotUpdateOrderStateAsReceived_WhenCustomerOrderExistAndCannotBeReceived()
        {
            //Arrange
            var context = Substitute.For<IRepository>();

            CustomerEntity user = new CustomerEntity()
            {
                Id = 1,
                Name = "test name",
                Surname = "test surname",
                DateOfBirth = new DateTime(),
                Email = "test email",
                Password = "testpass"
            };

            OrderEntity order = new OrderEntity()
            {
                Id = 1,
                Customer = user,
                Product = new ProductEntity(),
                State = OrderState.CanceledByUser
            };
            List<OrderEntity> orders = new List<OrderEntity>();
            orders.Add(order);
            context.Orders.Returns(orders);

            //Act
            var result = customerService.UpdateOrderStateAsReceived(order.Id, user.Id, context);
            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(context.Orders.First(o => o.Id == order.Id).State, order.State);
        }

        [TestMethod]
        public void UpdateOrderStateAsReceived_ShouldNotUpdateOrderStateAsReceived_WhenCustomerTryToReceivedSomeoneElseOrder()
        {
            //Arrange
            var context = Substitute.For<IRepository>();

            CustomerEntity user = new CustomerEntity()
            {
                Id = 1,
                Name = "test name",
                Surname = "test surname",
                DateOfBirth = new DateTime(),
                Email = "test email",
                Password = "testpass"
            };

            OrderEntity order = new OrderEntity()
            {
                Id = 1,
                Customer = user,
                Product = new ProductEntity(),
                State = OrderState.New
            };
            List<OrderEntity> orders = new List<OrderEntity>();
            orders.Add(order);
            context.Orders.Returns(orders);

            //Act
            var result = customerService.UpdateOrderStateAsReceived(order.Id, 2, context);

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(context.Orders.First(o => o.Id == order.Id).State, order.State);
        }

        [TestMethod]
        public void UpdateOrderStateAsReceived_ShouldNotUpdateOrderStateAsReceived_WhenCustomerOrOrderDoesNotExist()
        {
            //Arrange
            var context = Substitute.For<IRepository>();
            context.Orders.Returns(new List<OrderEntity>());

            //Act
            var result = customerService.UpdateOrderStateAsReceived(1, 1, context);

            //Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void UpdateCustomerInfo_ShouldUpdateCustomerInfo_WhenUserExist()
        {
            //Arrange
            var context = Substitute.For<IRepository>();

            CustomerEntity user = new CustomerEntity()
            {
                Id = 1,
                Name = "test name",
                Surname = "test surname",
                DateOfBirth = new DateTime(),
                Email = "test email",
                Password = "testpass"
            };
            List<CustomerEntity> users = new List<CustomerEntity>();
            users.Add(user);
            context.Customers.Returns(users);

            CustomerEntity userUpdate = new CustomerEntity()
            {
                Id = 1,
                Name = "new test name",
                Surname = "test surname",
                DateOfBirth = new DateTime(),
                Email = "test email",
                Password = "testpass"
            };

            //Act
            var result = customerService.UpdateCustomerInfo(userUpdate, context);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(context.Customers.First(c => c.Id == user.Id).ToString(), userUpdate.ToString());
        }

        [TestMethod]
        public void UpdateCustomerInfo_ShouldUpdateCustomerInfo_WhenUserDoesNotExist()
        {
            //Arrange
            var context = Substitute.For<IRepository>();

            CustomerEntity user = new CustomerEntity()
            {
                Id = 1,
                Name = "test name",
                Surname = "test surname",
                DateOfBirth = new DateTime(),
                Email = "test email",
                Password = "testpass"
            };
            List<CustomerEntity> users = new List<CustomerEntity>();
            users.Add(user);
            context.Customers.Returns(users);

            CustomerEntity userUpdate = new CustomerEntity()
            {
                Id = 2,
                Name = "new test name",
                Surname = "test surname",
                DateOfBirth = new DateTime(),
                Email = "test email",
                Password = "testpass"
            };

            //Act
            var result = customerService.UpdateCustomerInfo(userUpdate, context);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
*/