using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Infrastructure
{
    public interface IRepository<T> 
        where T: Entity, IUpdatebly<T>
    {
        void Add(T item);
        T GetById(int Id);
        IEnumerable<T> GetAll();
        void Update(T item);
    }
}
