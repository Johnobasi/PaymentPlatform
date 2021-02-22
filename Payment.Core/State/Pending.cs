using Payment.Core.Entities;
using Payment.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.State
{
    public class Pending : PaymentTransactionState
    {


        public override TransactionPayment ProcessTransaction(StateTransactionContext context, TransactionPayment payment)
        {
            payment.PaymentStatus = PaymentStatus.Pending;
            UnitOfWork.PaymentRepository.Add(payment);
            UnitOfWork.Commit();
            return payment;
        }
    }
}
