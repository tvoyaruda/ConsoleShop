using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace BLL
{
    public abstract class BaseService
    {
        public IEnumerable<ProductEntity> SearchbyName(string name, IRepository context)
        {
            return context.GetProductsByName(name);
        }
    }
}
