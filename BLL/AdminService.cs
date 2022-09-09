using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace BLL
{
    public class AdminService: BaseService
    {
        private int nextId = -1;
        private int nextProductId = -1;

        public IEnumerable<ProductEntity> GetProducts(IDataContex contex) => contex.Products;

        public bool CreateOrder(UserEntity currentCustomer, int productId, IDataContex contex)
        {
            ProductEntity product = contex.Products.Find(p => p.Id == productId);
            if (product == null)
                return false;
            if(nextId < 0)
                nextId = contex.Orders.LastOrDefault().Id + 1;
            OrderEntity order = new OrderEntity()
            {
                Id = nextId,
                State = OrderState.New,
                Product = product,
                Customer = currentCustomer
            };
            contex.Orders.Add(order);
            nextId++;
            return true;
        }

        public IEnumerable<OrderEntity> GetOrders(IDataContex contex) =>
            contex.Orders;

        public IEnumerable<UserEntity> GetCustomers(IDataContex contex) =>
            contex.Customers;

        public void CancelOrder(OrderEntity order, IDataContex contex) =>
            contex.Orders.Find(o => o.Id == order.Id).State = OrderState.CanceledByUser;

        public bool CreateOrder(int customerId, int productId, IDataContex contex)
        {
            UserEntity user = contex.Customers.Find(c => c.Id == customerId);
            ProductEntity product = contex.Products.Find(p => p.Id == productId);
            if (product == null || user == null)
                return false;
            if (nextId < 0)
                nextId = contex.Orders.LastOrDefault().Id + 1;
            OrderEntity order = new OrderEntity()
            {
                Id = nextId,
                State = OrderState.New,
                Product = product,
                Customer = user
            };
            contex.Orders.Add(order);
            nextId++;
            return true;
        }

        public bool ChangeOrderStatus(int orderId, int stateId, IDataContex contex)
        {
            OrderEntity changeOrder = contex.Orders.Find(o => o.Id == orderId);
            if (changeOrder.State != OrderState.CanceledByUser)
            {
                changeOrder.State = (OrderState)stateId;
                return true;
            }
            return false;
        }

        public bool ChangeUserInfo(AccountEntity user, IDataContex contex)
        {
            if (contex.Customers.Find(c => c.Id == user.Id) == null)
                return false;
            contex.Customers.FindLast(c => c.Id == user.Id).Update(user);
            return true;
        }

        public bool ChangeProductInfo(ProductEntity product, IDataContex contex)
        {
            if (contex.Products.Find(c => c.Id == product.Id) == null)
                return false;
            contex.Products.FindLast(c => c.Id == product.Id).Update(product);
            return true;
        }

        public bool AddNewProduct(ProductEntity product, IDataContex contex)
        {
            if (nextProductId < 0)
                nextProductId = contex.Products.LastOrDefault().Id + 1;
            product.Id = nextProductId;
            contex.Products.Add(product);
            nextProductId++;
            return true;
        }
    }
}
