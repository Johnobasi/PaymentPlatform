using Payment.Core.Entities;
using Payment.Core.interfaces;

namespace Payment.Core.State
{
    public abstract class PaymentTransactionState
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public abstract  TransactionPayment ProcessTransaction(StateTransactionContext context, TransactionPayment payment);
      
    }
}
