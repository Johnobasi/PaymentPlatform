using Payment.Core.Entities;
using Payment.Core.Enum;

namespace Payment.Core.State
{
    public class Failed : PaymentTransactionState
    {
     
        public override TransactionPayment ProcessTransaction(StateTransactionContext context, TransactionPayment payment)
        {
            payment.PaymentStatus = PaymentStatus.Failed;
            UnitOfWork.PaymentRepository.Update(payment);
            UnitOfWork.Commit();
            return payment;
        }
    }
}
