using AcmsAPI.Entities;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class AccessPassagePoint
    {
        public int AccessPassagePointId { get; set; }

        public Guid EmployeeId { get; set; }

        public int PassagePointId { get; set; }

        public DateTime Datetime { get; set; }

        public bool? IsUnauthorized { get; set; }

        public virtual Employee Employee { get; set; } = null!;

        public virtual PassagePoint PassagePoint { get; set; } = null!;
    }
}