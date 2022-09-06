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
        public CustomerService(IDataContex contex) : base(contex) 
        {
            nextId = this.Contex.Orders.LastOrDefault().Id + 1;
        }

        private int nextId;

        public IEnumerable<ProductEntity> ListOfProduct => this.Contex.Products;

        public bool CreateOrder(UserEntity currentCustomer, int productId)
        {
            ProductEntity product = this.Contex.Products.Find(p => p.Id == productId);
            if (product == null)
                return false;
            OrderEntity order = new OrderEntity()
            {
                Id = nextId,
                State = OrderState.New,
                Product = product,
                Customer = currentCustomer
            };       
            this.Contex.Orders.Add(order);
            nextId++;
            return true;
        }

        public IEnumerable<OrderEntity> ViewOrders(int customerId) =>
            this.Contex.Orders.Where(o => o.Customer.Id == customerId).Select(o => o);

        public void CancelOrder(OrderEntity order) =>
            this.Contex.Orders.Find(o => o.Id == order.Id).State = OrderState.CanceledByUser;
    }
}
