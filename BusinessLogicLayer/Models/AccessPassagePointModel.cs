using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class AccessPassagePointModel
    {
        public int AccessPassagePointId { get; set; }

        public Guid EmployeeId { get; set; }

        public int PassagePointId { get; set; }

        public DateTime Datetime { get; set; }

        public bool? IsUnauthorized { get; set; }

        public virtual EmployeeModel Employee { get; set; } = null!;

        public virtual PassagePointModel PassagePoint { get; set; } = null!;
    }
}