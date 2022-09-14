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
    public class State
    {
        private readonly IRepository _dataContext;
        private IOperations _userOperations;

        public State()
        {
            _dataContext = new ReadonlyConstDataContext();
            _userOperations = new GuestOperations();
        }

        public void Run()
        {
            bool continueCode = true;
            while (continueCode)
            {
                continueCode = _userOperations.ShowAvailableOperations(_dataContext, ref _userOperations);
            }
        }
    }
}
