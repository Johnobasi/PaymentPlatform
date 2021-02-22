using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Api.Dto;
using Payment.Api.Response;
using Payment.Core.Constant;
using Payment.Core.Entities;
using Payment.Core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ICheapPaymentGateway _cheapPayment;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly IMapper _mapper;

        public PaymentController(ICheapPaymentGateway cheapPayment,
            IExpensivePaymentGateway expensivePaymentGateway,
            IMapper mapper)
        {
           _cheapPayment = cheapPayment;
            _expensivePaymentGateway = expensivePaymentGateway;
            _mapper = mapper;
        }
        public async Task<ActionResult<BaseResponse<TransactionPaymentResponseDto>>> Payment(TransactionPaymentDto request)
        {
            var paymentResponse = default(TransactionPayment);
            var response = default(TransactionPaymentResponseDto);
            try
            {
                var paymentRequest = _mapper.Map<TransactionPaymentDto, TransactionPayment>(request);
                if (request.Amount <= 20)
                    paymentResponse = _cheapPayment.HandlePayment(paymentRequest);
                else if (request.Amount > 20 && request.Amount <= 500)
                    paymentResponse = _expensivePaymentGateway.HandlePayment(paymentRequest);

                if(paymentResponse is null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse<TransactionPaymentResponseDto>
                    {
                        Code = Constants.API_INTERNAL_SERVER_ERROR,
                        Data = null,
                        IsSuccessful= false,
                    });

                response = _mapper.Map<TransactionPayment, TransactionPaymentResponseDto>(paymentRequest);
                
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse<TransactionPaymentResponseDto>
                {
                    Code = Constants.API_INTERNAL_SERVER_ERROR,
                    Data = null,
                    IsSuccessful = false,
                });
            }
            return Ok(new BaseResponse<TransactionPaymentResponseDto>
            {
                Code = Constants.API_SUCCESSFUL,
                Data = response,
                IsSuccessful = true,
            });
        }
    }
}
