using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public enum OrderState
    {
        New,
        CanceledByAdmin,
        PaymentReceived,
        Sent,
        Received,
        Completed,
        CanceledByUser
    }
}
