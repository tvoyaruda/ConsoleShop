using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public interface IRepository
    {
        void AddOrder(OrderEntity order);
        void AddProduct(ProductEntity product);
        void AddCustomer(CustomerEntity customer);
        void AddAdmin(AdminEntity admin);
        
        OrderEntity GetOrderById(int orderId);
        ProductEntity GetProductById(int productId);
        CustomerEntity GetCustomerById(int customerId);
        CustomerEntity GetCustomerByEmail(string email);
        CustomerEntity GetCustomerByEmailAndPass(string email, string pass);
        AdminEntity GetAdminById(int adminId);
        AdminEntity GetAdminByEmail(string email);
        AdminEntity GetAdminByEmailAndPass(string email, string pass);

        IEnumerable<OrderEntity> GetOrders();
        IEnumerable<OrderEntity> GetOrdersByCustomerId(int customerId);
        IEnumerable<ProductEntity> GetProducts();
        IEnumerable<ProductEntity> GetProductsByName(string name);
        IEnumerable<CustomerEntity> GetCustomers();
        IEnumerable<AdminEntity> GetAdmins();

        void UpdateCustomer(CustomerEntity customer);
        void UpdateProduct(ProductEntity product);
        void UpdateOrderState(int orderId, OrderState orderState);
    }
}
