using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace BLL
{
    public class CustomerService: BaseService
    {
        private int nextId = -1;

        public IEnumerable<ProductEntity> ListOfProduct(IDataContext context) => context.Products;

        public bool CreateOrder(AccountEntity currentCustomer, int productId, IDataContext context)
        {
            ProductEntity product = context.Products.Find(p => p.Id == productId);
            if (product == null)
                return false;
            if(nextId < 0)
                nextId = context.Orders.LastOrDefault().Id + 1;
            OrderEntity order = new OrderEntity()
            {
                Id = nextId,
                State = OrderState.New,
                Product = product,
                Customer = currentCustomer
            };
            context.Orders.Add(order);
            nextId++;
            return true;
        }

        public IEnumerable<OrderEntity> ViewOrders(int customerId, IDataContext context) =>
            context.Orders.Where(o => o.Customer.Id == customerId).Select(o => o);

        public bool CancelOrder(int orderId, IDataContext context)
        {
            OrderEntity changeOrder = context.Orders.Find(o => o.Id == orderId);
            if(changeOrder.State == OrderState.New)
            {
                changeOrder.State = OrderState.CanceledByUser;
                return true;
            }
            return false;
        }

        public bool ReceivedOrder(int orderId, IDataContext context)
        {
            OrderEntity changeOrder = context.Orders.Find(o => o.Id == orderId);
            if (changeOrder.State != OrderState.CanceledByUser && changeOrder.State != OrderState.CanceledByAdmin)
            {
                changeOrder.State = OrderState.Received;
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
    }
}
