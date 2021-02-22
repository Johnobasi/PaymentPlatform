using Microsoft.EntityFrameworkCore;
using Payment.Core.Entities;
using Payment.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Infrastructure.Repository
{
    public class TransactionPaymentDbContext:DbContext
    {
        public TransactionPaymentDbContext(DbContextOptions<TransactionPaymentDbContext> options) : base(options)
        {

        }
       public DbSet<TransactionPayment> TransactionPayments { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionPayment>(e =>
            {
                e.HasKey(t => t.Id);
                e.Property(e => e.Id).
                ValueGeneratedOnAdd();
                e.Property(e => e.PaymentStatus).HasConversion(
            v => v.ToString(),
            v => (PaymentStatus)Enum.Parse(typeof(PaymentStatus), v)).IsRequired();
                e.Property(e => e.ExpirationDate).IsRequired();
                e.Property(e => e.CreditCardNumber).IsRequired();
                e.Property(p => p.CardHolder).IsRequired();
                e.Property(p => p.Amount).HasColumnType("decimal(5,3)").IsRequired();


            });
                
               
        }
    }
}
