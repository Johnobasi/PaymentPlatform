using Payment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.interfaces
{
    public interface IPaymentRepository:IRepository<TransactionPayment>
    { }
}
