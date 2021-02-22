using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using System.Reflection;
using AutoMapper;
using Payment.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Payment.Core.interfaces;
using Payment.Core.State;

namespace Payment.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
       
            services.AddControllers()
                .AddFluentValidation(opt => 
                {
                    opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                 });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddDbContext<TransactionPaymentDbContext>(opt => {
                opt.UseSqlServer(Configuration.GetConnectionString("PaymentTransactionDb"));
            });
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<StateTransactionContext>();
            services.AddScoped<ICheapPaymentGateway, CheapPaymentGateway>();
            services.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
