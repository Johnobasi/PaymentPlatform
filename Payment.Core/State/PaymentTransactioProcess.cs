using Payment.Core.Entities;
using Payment.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.State
{
    public static class PaymentTransactioProcess
    {
        public static void ProcessTransaction(StateTransactionContext context, PaymentStatus paymentStatus)
        {
            switch (paymentStatus)
            {
                case PaymentStatus.Pending:
                    context.TransitionToState(new Pending());
                    break;
                case PaymentStatus.Failed:
                    context.TransitionToState(new Failed());
                    break;
                case PaymentStatus.Processed:
                    context.TransitionToState(new Processed());
                    break;
            }

        }
    }

}
