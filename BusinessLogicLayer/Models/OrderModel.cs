using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        public string OrderNumber { get; set; } = null!;

        public int TypeOrderId { get; set; }

        public byte[] OrderFile { get; set; } = null!;

        public Guid EmployeeId { get; set; }

        public DateOnly StartDateAction { get; set; }

        public DateOnly? EndDateAction { get; set; }

        public virtual EmployeeModel Employee { get; set; } = null!;

        public virtual TypeOrderModel TypeOrder { get; set; } = null!;
    }
}