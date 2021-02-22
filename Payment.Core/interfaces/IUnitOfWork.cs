using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.interfaces
{
    public interface IUnitOfWork
    {
        IPaymentRepository PaymentRepository { get; set; }
        bool Commit();
    }
}