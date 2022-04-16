using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Application.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public AddressDTO Address { get; set; }
        public string BuyerId { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
