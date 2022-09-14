using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
    public interface IRepository<T> 
        where T: BaseEntity, IUpdatebly<T>
    {
        void CreateItem(T item);
        T GetById(int Id);
        IEnumerable<T> GetAll();
        void UpdateItem(T item);
    }
}
