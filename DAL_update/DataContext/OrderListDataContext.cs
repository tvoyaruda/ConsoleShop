using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Data
{
    public class OrderListContext : ListContext<OrderEntity>
    {
        public OrderListContext()
        {
            DataList = new List<OrderEntity>
            {
                new OrderEntity
                {
                    Id = 1,
                    CustomerId = 1,
                    ProductId = 2,
                    CreatedTime = new DateTime(2022,9,1),
                    State = OrderState.PaymentReceived
                },
                new OrderEntity
                {
                    Id = 2,
                    CustomerId =  1,
                    ProductId =  4,
                    CreatedTime = new DateTime(2022,9,3),
                    State = OrderState.New
                },
                new OrderEntity
                {
                    Id = 3,
                    CustomerId =  2,
                    ProductId =  3,
                    CreatedTime = new DateTime(2022,9,2),
                    State = OrderState.Sent
                },
                new OrderEntity
                {
                    Id = 4,
                    CustomerId =  3,
                    ProductId =  5,
                    CreatedTime = new DateTime(2022,9,4),
                    State = OrderState.New
                },
                new OrderEntity
                {
                    Id = 5,
                    CustomerId =  4,
                    ProductId =  1,
                    CreatedTime = new DateTime(2022,9,1),
                    State = OrderState.New
                },
                new OrderEntity
                {
                    Id = 6,
                    CustomerId =  4,
                    ProductId =  6,
                    CreatedTime = new DateTime(2022,9,3),
                    State = OrderState.PaymentReceived
                },
                new OrderEntity
                {
                    Id = 7,
                    CustomerId =  5,
                    ProductId =  2,
                    CreatedTime = new DateTime(2022,9,4),
                    State = OrderState.New
                },
                new OrderEntity
                {
                    Id = 8,
                    CustomerId =  6,
                    ProductId =  5,
                    CreatedTime = new DateTime(2022,9,5),
                    State = OrderState.PaymentReceived
                }
            };
        }
    }
}
