using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Domain;
using BLL;

namespace PL
{
    public interface IOperations
    {
        bool ShowAvailableOperations(UserEntity user, out bool continueApp);
    }
}
