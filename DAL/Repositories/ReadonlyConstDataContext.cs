using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ReadonlyConstDataContext : IRepository
    {
        public List<CustomerEntity> Customers { get; }
        public List<AdminEntity> Admins { get; }
        public List<OrderEntity> Orders { get; }
        public List<ProductEntity> Products { get; }
        private int nextOrderId;
        private int nextProductId;
        private int nextCustomerId;
        private int nextAdminId;

        public ReadonlyConstDataContext()
        {
            Customers = new List<CustomerEntity>
            {
                new CustomerEntity
                {
                    Id = 1,
                    Name = "Adam",
                    Surname = "Rokich",
                    DateOfBirth = new DateTime(1994,7,1),
                    Email = "1", //"user1@gmail.com"
                    Password = "1" //"user1"
                },
                new CustomerEntity
                {
                    Id = 2,
                    Name = "Anna",
                    Surname = "Konel",
                    DateOfBirth = new DateTime(1991,11,25),
                    Email = "user2@gmail.com",
                    Password = "user2"
                },
                new CustomerEntity
                {
                    Id = 3,
                    Name = "Bell",
                    Surname = "Myrow",
                    DateOfBirth = new DateTime(1996,10,11), 
                    Email = "user3@gmail.com",
                    Password = "user3"
                },
                new CustomerEntity
                {
                    Id = 4,
                    Name = "Solar",
                    Surname = "Nisow",
                    DateOfBirth = new DateTime(1998,7,31), 
                    Email = "user4@gmail.com",
                    Password = "user4"
                },
                new CustomerEntity
                {
                    Id = 5,
                    Name = "Mirta",
                    Surname = "Dalb",
                    DateOfBirth = new DateTime(1997,2,3),
                    Email = "user5@gmail.com",
                    Password = "user5"
                },
                new CustomerEntity
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

            nextCustomerId = Customers.Last().Id + 1;
            nextAdminId = Admins.Last().Id + 1;
            nextProductId = Products.Last().Id + 1;
            nextOrderId = Orders.Last().Id + 1;
        }

        public void AddOrder(OrderEntity order)
        {
            order.Id = nextOrderId;
            Orders.Add(order);
            nextOrderId++;
        }

        public void AddProduct(ProductEntity product)
        {
            product.Id = nextProductId;
            Products.Add(product);
            nextProductId++;
        }

        public void AddCustomer(CustomerEntity customer)
        {
            customer.Id = nextCustomerId;
            Customers.Add(customer);
            nextCustomerId++;
        }

        public void AddAdmin(AdminEntity admin)
        {
            admin.Id = nextAdminId;
            Admins.Add(admin);
            nextAdminId++;
        }

        public OrderEntity GetOrderById(int orderId) => Orders.First(e => e.Id == orderId);

        public ProductEntity GetProductById(int productId) => Products.First(e => e.Id == productId);

        public CustomerEntity GetCustomerById(int customerId) => Customers.First(e => e.Id == customerId);

        public CustomerEntity GetCustomerByEmail(string email)
            => Customers.First(c => c.Email == email);

        public CustomerEntity GetCustomerByEmailAndPass(string email, string pass)
            => Customers.First(c => c.Email == email && c.Password == pass);

        public AdminEntity GetAdminById(int adminId) => Admins.First(e => e.Id == adminId);

        public AdminEntity GetAdminByEmail(string email)
            => Admins.First(c => c.Email == email);

        public AdminEntity GetAdminByEmailAndPass(string email, string pass)
            => Admins.First(c => c.Email == email && c.Password == pass);

        public IEnumerable<OrderEntity> GetOrders() => Orders;

        public IEnumerable<OrderEntity> GetOrdersByCustomerId(int customerId)
            => Orders.Where(e => e.Customer.Id == customerId);

        public IEnumerable<ProductEntity> GetProducts() => Products;

        public IEnumerable<ProductEntity> GetProductsByName(string name)
        {
            Func<ProductEntity, bool> rule = p => p.Name.ToLower().Contains(name.ToLower());
            return Products.Where(rule);
        }

        public IEnumerable<CustomerEntity> GetCustomers() => Customers;

        public IEnumerable<AdminEntity> GetAdmins() => Admins;

        public void UpdateCustomer(CustomerEntity customer) => GetCustomerById(customer.Id).Update(customer);

        public void UpdateProduct(ProductEntity product) => GetProductById(product.Id).Update(product);

        public void UpdateOrderState(int orderId, OrderState orderState) => GetOrderById(orderId).State = orderState;
    }
}
