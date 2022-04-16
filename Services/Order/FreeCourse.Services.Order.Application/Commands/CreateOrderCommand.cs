using FreeCourse.Services.Order.Application.DTOs;
using FreeCourse.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Application.Commands
{
    public class CreateOrderCommand : IRequest<Response<CreatedOrderDTO>>
    {
        public string BuyerId { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
        public AddressDTO Address { get; set; }
    }
}
