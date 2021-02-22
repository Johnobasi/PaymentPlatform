using Payment.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Core.Entities
{
    public class TransactionPayment: BaseEntity
    {
   
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus  PaymentStatus { get; set; }
    }
    
}
