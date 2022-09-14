using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class ListContext<T>
    {
        public List<T> DataList { get; protected set; }
    }
}
