using Payment.Core.Entities;
using Payment.Core.interfaces;
using Payment.Core.State;
using System;
using System.Threading;

namespace Payment.Infrastructure.Repository
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        private readonly StateTransactionContext _context;

        public ExpensivePaymentGateway(StateTransactionContext context)
        {
            _context = context;
        }
        public TransactionPayment HandlePayment(TransactionPayment payment)
        {
            TransactionPayment transactionPayment = null;
            try
            {
                _context.TransitionToState(new Pending());
                transactionPayment = _context.ProcessTransaction(payment);
                Thread.Sleep(1000);// external call to payment api
                _context.TransitionToState(new Processed());
                transactionPayment = _context.ProcessTransaction(transactionPayment);

       
            }
            catch (Exception ex)
            {

                _context.TransitionToState(new Failed());
                return _context.ProcessTransaction(payment);
            }
            return transactionPayment;
        }
    }
}
