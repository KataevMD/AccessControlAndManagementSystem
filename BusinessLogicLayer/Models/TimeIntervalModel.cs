using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class TimeIntervalModel
    {
        public int TimeIntervalId { get; set; }

        public string Title { get; set; } = null!;

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public int TimeZoneId { get; set; }

        public virtual ICollection<DaysTimeZoneModel> DaysTimeZones { get; set; } = new List<DaysTimeZoneModel>();

        public virtual TimeZoneModel TimeZone { get; set; } = null!;
    }
}