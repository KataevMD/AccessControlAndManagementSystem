using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class DayModel
    {
        public int DayId { get; set; }

        public string Title { get; set; } = null!;

        public virtual ICollection<DaysTimeZoneModel> DaysTimeZones { get; set; } = new List<DaysTimeZoneModel>();
    }
}