using Payment.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Api.Dto
{
    public class TransactionPaymentResponseDto
    {
        public string TXT_REF { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
