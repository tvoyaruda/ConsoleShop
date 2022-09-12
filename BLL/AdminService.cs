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

        public IEnumerable<ProductEntity> GetProducts(IDataContext context) => context.Products;

        public IEnumerable<OrderEntity> GetOrders(IDataContext context) =>
            context.Orders;

        public IEnumerable<UserEntity> GetCustomers(IDataContext context) =>
            context.Customers;

        public void CancelOrder(OrderEntity order, IDataContext context) =>
            context.Orders.Find(o => o.Id == order.Id).State = OrderState.CanceledByUser;

        public bool CreateOrder(int customerId, int productId, IDataContext context)
        {
            UserEntity user = context.Customers.Find(c => c.Id == customerId);
            ProductEntity product = context.Products.Find(p => p.Id == productId);
            if (product == null || user == null)
                return false;
            if (nextId < 0)
                nextId = context.Orders.LastOrDefault().Id + 1;
            OrderEntity order = new OrderEntity()
            {
                Id = nextId,
                State = OrderState.New,
                Product = product,
                Customer = user
            };
            context.Orders.Add(order);
            nextId++;
            return true;
        }

        public bool ChangeOrderStatus(int orderId, int stateId, IDataContext context)
        {
            OrderEntity changeOrder = context.Orders.Find(o => o.Id == orderId);
            if (changeOrder.State != OrderState.CanceledByUser)
            {
                changeOrder.State = (OrderState)stateId;
                return true;
            }
            return false;
        }

        public bool ChangeUserInfo(AccountEntity user, IDataContext context)
        {
            if (context.Customers.Find(c => c.Id == user.Id) == null)
                return false;
            context.Customers.FindLast(c => c.Id == user.Id).Update(user);
            return true;
        }

        public bool ChangeProductInfo(ProductEntity product, IDataContext context)
        {
            if (context.Products.Find(c => c.Id == product.Id) == null)
                return false;
            context.Products.FindLast(c => c.Id == product.Id).Update(product);
            return true;
        }

        public bool AddNewProduct(ProductEntity product, IDataContext context)
        {
            if (nextProductId < 0)
                nextProductId = context.Products.LastOrDefault().Id + 1;
            product.Id = nextProductId;
            context.Products.Add(product);
            nextProductId++;
            return true;
        }
    }
}
