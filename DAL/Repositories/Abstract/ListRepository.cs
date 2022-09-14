using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities;

namespace Data
{
    public abstract class ListRepository<T,U> : IRepository<T> 
        where T : BaseEntity, IUpdatebly<T>
        where U : ListContext<T>
    {
        protected U Context { get; }
        protected int nextId;

        public ListRepository(U context)
        {
            Context = context;
            nextId = Context.DataList.Last().Id + 1;
        }

        public void Create(T item)
        {
            item.Id = nextId;
            Context.DataList.Add(item);
            nextId++;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.DataList;
        }

        public T GetById(int Id)
        {
            return Context.DataList.First(p => p.Id == Id);
        }

        public void Update(T item)
        {
             GetById(item.Id).Update(item);
        }
    }
}
