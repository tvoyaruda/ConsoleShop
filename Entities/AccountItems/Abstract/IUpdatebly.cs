using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{ 
    public interface IUpdatebly<in T>
    {
        void Update(T item);
    }
}
