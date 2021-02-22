using Payment.Core.Entities;
using Payment.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.State
{
    public class Processed : PaymentTransactionState
    {
       

        public override TransactionPayment ProcessTransaction(StateTransactionContext context, TransactionPayment payment)
        {
            payment.PaymentStatus = PaymentStatus.Processed;
            UnitOfWork.PaymentRepository.Update(payment);
            UnitOfWork.Commit();
            return payment;
        }
    }
}
