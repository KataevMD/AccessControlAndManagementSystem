using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class TypeOrderModel
    {
        public int TypeOrderId { get; set; }

        public string Title { get; set; } = null!;

        public virtual ICollection<OrderModel> Orders { get; set; } = new List<OrderModel>();
    }
}