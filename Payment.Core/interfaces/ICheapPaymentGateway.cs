using Payment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.interfaces
{
    public interface ICheapPaymentGateway
    {
        TransactionPayment HandlePayment(TransactionPayment payment);
    }
}
