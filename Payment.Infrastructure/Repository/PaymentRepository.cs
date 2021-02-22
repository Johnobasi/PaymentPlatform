using Payment.Core.Entities;
using Payment.Core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Infrastructure.Repository
{
    public class PaymentRepository:Repository<TransactionPayment>,IPaymentRepository
    {
        public PaymentRepository(TransactionPaymentDbContext context):base(context)
        {
        }
    }
}
