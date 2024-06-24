using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class TypePointByAppointmentModel
    {
        public int TypePointId { get; set; }

        public string Title { get; set; } = null!;

        public virtual ICollection<PassagePointModel> PassagePoints { get; set; } = new List<PassagePointModel>();
    }
}