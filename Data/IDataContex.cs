using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public interface IDataContex
    {
        List<UserEntity> Customers { get; }
        List<AdminEntity> Admins { get; }
        List<OrderEntity> Orders { get; }
        List<ProductEntity> Products { get; }
    }
}
