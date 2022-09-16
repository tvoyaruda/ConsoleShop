using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain;

namespace Infrastructure
{
    public abstract class ListRepository<T> : IRepository<T> 
        where T : Entity, IUpdatebly<T>
    {
        protected ListContext<T> Context { get; }
        protected int nextId;

        public ListRepository(ListContext<T> context)
        {
            Context = context;
            nextId = Context.ContextList.Last().Id + 1;
        }

        public void Add(T item)
        {
            item.Id = nextId;
            Context.ContextList.Add(item);
            nextId++;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.ContextList;
        }

        public T GetById(int Id)
        {
            return Context.ContextList.First(p => p.Id == Id);
        }

        public void Update(T item)
        {
             GetById(item.Id).Update(item);
        }
    }
}
