using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class TimeZoneModel
    {
        public int TimeZoneId { get; set; }

        public string Title { get; set; } = null!;

        public virtual ICollection<TimeIntervalModel> TimeIntervals { get; set; } = new List<TimeIntervalModel>();

        public virtual ICollection<TimeZonePassagePointModel> TimeZonePassagePoints { get; set; } = new List<TimeZonePassagePointModel>();
    }
}