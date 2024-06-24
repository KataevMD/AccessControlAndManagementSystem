using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class TimeZonePassagePointModel
    {
        public int AccessLevelId { get; set; }

        public int PassagePointId { get; set; }

        public int TimeZoneId { get; set; }

        public virtual AccessLevelModel AccessLevel { get; set; } = null!;

        public virtual PassagePointModel PassagePoint { get; set; } = null!;

        public virtual TimeZoneModel TimeZone { get; set; } = null!;
    }
}