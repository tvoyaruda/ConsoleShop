using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ListContext<T>
    {
        public List<T> ContextList { get; protected set; }
    }
}
