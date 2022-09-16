using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    ///<summary>
    ///Description basic entity that has only Id field
    ///</summary>
    public abstract class Entity
    {
        /// <value>
        /// The <c>Id</c> property represents an uniq Id for this instance.
        /// </value>
        public int Id { get; set; }
    }
}
