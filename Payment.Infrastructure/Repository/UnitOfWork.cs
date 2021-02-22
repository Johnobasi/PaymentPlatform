using Payment.Core.interfaces;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TransactionPaymentDbContext _context;

        public IPaymentRepository PaymentRepository { get ; set ; }
        public UnitOfWork(IPaymentRepository paymentRepository,TransactionPaymentDbContext context)
        {
            PaymentRepository = paymentRepository;
            _context = context;
        }

        public bool Commit()
        {
            return  _context.SaveChanges() > 0;
        }
    }
}
