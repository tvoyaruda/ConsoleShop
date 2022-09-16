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
    public static class OperationsSelector
    {

        private static Dictionary<UserRoles, Type> keyValuePairs = new Dictionary<UserRoles, Type>
        {
            {UserRoles.Customer, typeof(CustomerOperations)},
            {UserRoles.Admin, typeof(AdminOperations)}
        };

        public static Type GetOperations(UserEntity user)
            => keyValuePairs.TryGetValue(user.Role, out var value) ? value : typeof(GuestOperations);
    }
}
