using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;
using BLL;

namespace PL
{
    public interface IOperations
    {
        void SetUser(AccountEntity user);
        bool ShowAvailableOperations();
    }
}
