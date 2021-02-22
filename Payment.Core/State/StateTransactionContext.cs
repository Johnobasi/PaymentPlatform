using Microsoft.Extensions.DependencyInjection;
using Payment.Core.Entities;
using Payment.Core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.State
{
    public class StateTransactionContext
    {
        public StateTransactionContext(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private PaymentTransactionState CurrentState;
        private readonly IUnitOfWork _unitOfWork;

        public void TransitionToState(PaymentTransactionState transitionState)
        {
            CurrentState = transitionState;
            CurrentState.UnitOfWork = _unitOfWork;
           
          
        }
        public TransactionPayment ProcessTransaction(TransactionPayment payment)
        {
            return   CurrentState.ProcessTransaction(this, payment);
           
        }

       
    }
}
