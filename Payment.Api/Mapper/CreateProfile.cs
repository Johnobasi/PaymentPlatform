using AutoMapper;
using Payment.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payment.Core.Entities;
namespace Payment.Api.Mapper
{
    public class CreateProfile:Profile
    {
        public CreateProfile()
        {

            CreateMap<TransactionPaymentDto, TransactionPayment>(
                ).ReverseMap();
            CreateMap<TransactionPayment, TransactionPaymentResponseDto>
                ().ForMember(e => e.TXT_REF, o => o.MapFrom(s => s.Id.ToString()));
        }
    }
}
