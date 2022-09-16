using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Infrastructure
{
    public class ListDataContext
    {
        public OrderRepository Orders { get; }
        public ProductRepository Products { get; }
        public UserRepository Users { get; }

        public ListDataContext(ListContext<OrderEntity> ordersList, ListContext<ProductEntity> productsList, ListContext<UserEntity> usersList)
        {
            Orders = new OrderRepository(ordersList);
            Products = new ProductRepository(productsList);
            Users = new UserRepository(usersList);
        }
    }
}
