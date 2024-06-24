using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class DaysTimeZoneModel
    {
        public int DaysTimeZoneId { get; set; }

        public int TimeIntervalId { get; set; }

        public int DayId { get; set; }

        public virtual DayModel Day { get; set; } = null!;

        public virtual TimeIntervalModel TimeInterval { get; set; } = null!;
    }
}