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
        private readonly IDataContex _dataContex;
        private IOperations _userOperations;

        public State()
        {
            _dataContex = new DataContex();
            _userOperations = new GuestOperations();
        }

        public void Run()
        {
            bool continueCode = true;
            while (continueCode)
            {
                continueCode = _userOperations.ShowAvalibleOperations(_dataContex, ref _userOperations);
            }
        }
    }
}
