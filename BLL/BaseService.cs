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
        protected IDataContex Contex { get; }
        
        protected BaseService(IDataContex contex)
        {
            Contex = contex;
        }

        public IEnumerable<ProductEntity> SearchbyName(string name)
        {
            return Contex.Products.Where(p => p.Name.Contains(name)).Select(p => p);
        }
    }
}
