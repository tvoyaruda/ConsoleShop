using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUpdatebly<in T>
    {
        /// <summary>Updates the specified item.</summary>
        /// <param name="item">The item.</param>
        void Update(T item);
    }
}
