using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities;

namespace Data
{
    public abstract class ListRepository<T,U> : IRepository<T> 
        where T : BaseEntity, IUpdatebly<T>
        where U : ListContext<T>, new()
    {
        protected U Context { get; }
        protected int nextId;

        public ListRepository()
        {
            Context = new U();
            nextId = Context.DataList.Last().Id + 1;
        }

        public void CreateItem(T item)
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

        public void UpdateItem(T item)
        {
             GetById(item.Id).Update(item);
        }
    }
}
