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
    public class State
    {
        private readonly ListDataContext dataContext;
        private UserEntity user
        {
            get;
            set;
        }
        private IOperations _userOperations;

        public State()
        {
            dataContext = new ListDataContext(new OrderListContext(), new ProductListContext(), new UserListContext());
            user = null;
            _userOperations = new GuestOperations(dataContext);
        }

        private void ChangeOperation()
        {
            _userOperations = (IOperations)OperationsSelector.GetOperations(user).GetConstructor(new[] { typeof(ListDataContext) }).Invoke(new[] { dataContext });
        }

        public void Run()
        {
            bool continueCode = true;
            while (continueCode)
            {
                continueCode = _userOperations.ShowAvailableOperations(user, out continueCode);
                ChangeOperation();
            }
        }
    }
}
