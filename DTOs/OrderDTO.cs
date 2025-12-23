using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record OrderCreateDTO
    {
        public int UserId { get; set; }

        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }

    public record OrderReadDTO
    {
        public int OrderId { get; set; }

        public DateOnly OrderDate { get; set; }

        public decimal? OrderSum { get; set; }

        public int UserId { get; set; }

        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
