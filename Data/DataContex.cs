using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContex : IDataContex
    {
        public List<UserEntity> Customers { get; }
        public List<AdminEntity> Admins { get; }
        public List<OrderEntity> Orders { get; }
        public List<ProductEntity> Products { get; }

        public DataContex()
        {
            Customers = new List<UserEntity>
            {
                new UserEntity
                {
                    Id = 1,
                    Name = "Adam",
                    Surname = "Rokich",
                    DateOfBirth = new DateTime(1994,7,1),
                    Email = "1", //"user1@gmail.com"
                    Password = "1" //"user1"
                },
                new UserEntity
                {
                    Id = 2,
                    Name = "Anna",
                    Surname = "Konel",
                    DateOfBirth = new DateTime(1991,11,25),
                    Email = "user2@gmail.com",
                    Password = "user2"
                },
                new UserEntity
                {
                    Id = 3,
                    Name = "Bell",
                    Surname = "Myrow",
                    DateOfBirth = new DateTime(1996,10,11), 
                    Email = "user3@gmail.com",
                    Password = "user3"
                },
                new UserEntity
                {
                    Id = 4,
                    Name = "Solar",
                    Surname = "Nisow",
                    DateOfBirth = new DateTime(1998,7,31), 
                    Email = "user4@gmail.com",
                    Password = "user4"
                },
                new UserEntity
                {
                    Id = 5,
                    Name = "Mirta",
                    Surname = "Dalb",
                    DateOfBirth = new DateTime(1997,2,3),
                    Email = "user5@gmail.com",
                    Password = "user5"
                },
                new UserEntity
                {
                    Id = 6,
                    Name = "Viktor",
                    Surname = "Sterov",
                    DateOfBirth = new DateTime(1999,4,16), 
                    Email = "user6@gmail.com",
                    Password = "user6"
                },
            };

            Admins = new List<AdminEntity>
            {
                new AdminEntity
                {
                    Id = 1,
                    Name = "David",
                    Surname = "Glinth",
                    DateOfBirth = new DateTime(1999,4,16),
                    Email = "admin1@gmail.com",
                    Password = "admin1"
                },
                new AdminEntity
                {
                    Id = 2,
                    Name = "Lora",
                    Surname = "Linder",
                    DateOfBirth = new DateTime(1999,5,15),
                    Email = "admin2@gmail.com",
                    Password = "admin2"
                },
                new AdminEntity
                {
                    Id = 3,
                    Name = "Test",
                    Surname = "Test",
                    DateOfBirth = new DateTime(1999,5,15),
                    Email = "a1",
                    Password = "a1"
                }
            };

            Products = new List<ProductEntity>
            {
                new ProductEntity
                {
                    Id = 1,
                    Name = "Fanta",
                    Category = "drinks",
                    Price = 19.90M
                },
                new ProductEntity
                {
                    Id = 2,
                    Name = "Strite",
                    Category = "drinks",
                    Price = 29.90M
                },
                new ProductEntity
                {
                    Id = 3,
                    Name = "Banana",
                    Category = "fruits",
                    Price = 67.20M
                },
                new ProductEntity
                {
                    Id = 4,
                    Name = "Apple",
                    Category = "fruits",
                    Price = 17.10M
                },
                new ProductEntity
                {
                    Id = 5,
                    Name = "Potato",
                    Category = "vegetables",
                    Price = 12.50M
                },
                new ProductEntity
                {
                    Id = 6,
                    Name = "Tomato",
                    Category = "vegetables",
                    Price = 56.40M
                }
            };

            Orders = new List<OrderEntity>
            {
                new OrderEntity
                {
                    Id = 1,
                    Customer = Customers.First(c => c.Id == 1),
                    Product = Products.First(p => p.Id == 2),
                    CreatedTime = new DateTime(2022,9,1),
                    State = OrderState.PaymentReceived
                },
                new OrderEntity
                {
                    Id = 2,
                    Customer = Customers.First(c => c.Id == 1),
                    Product = Products.First(p => p.Id == 4),
                    CreatedTime = new DateTime(2022,9,3),
                    State = OrderState.New
                },
                new OrderEntity
                {
                    Id = 3,
                    Customer = Customers.First(c => c.Id == 2),
                    Product = Products.First(p => p.Id == 3),
                    CreatedTime = new DateTime(2022,9,2),
                    State = OrderState.Sent
                },
                new OrderEntity
                {
                    Id = 4,
                    Customer = Customers.First(c => c.Id == 3),
                    Product = Products.First(p => p.Id == 5),
                    CreatedTime = new DateTime(2022,9,4),
                    State = OrderState.New
                },
                new OrderEntity
                {
                    Id = 5,
                    Customer = Customers.First(c => c.Id == 4),
                    Product = Products.First(p => p.Id == 1),
                    CreatedTime = new DateTime(2022,9,1),
                    State = OrderState.New
                },
                new OrderEntity
                {
                    Id = 6,
                    Customer = Customers.First(c => c.Id == 4),
                    Product = Products.First(p => p.Id == 6),
                    CreatedTime = new DateTime(2022,9,3),
                    State = OrderState.PaymentReceived
                },
                new OrderEntity
                {
                    Id = 7,
                    Customer = Customers.First(c => c.Id == 5),
                    Product = Products.First(p => p.Id == 2),
                    CreatedTime = new DateTime(2022,9,4),
                    State = OrderState.New
                },
                new OrderEntity
                {
                    Id = 8,
                    Customer = Customers.First(c => c.Id == 6),
                    Product = Products.First(p => p.Id == 5),
                    CreatedTime = new DateTime(2022,9,5),
                    State = OrderState.PaymentReceived
                }
            };
        }
    }
}
