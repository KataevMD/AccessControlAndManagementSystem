using System;
using System.Collections.Generic;

namespace AcmsAPI.Entities;

public partial class TypeOrder
{
    public int TypeOrderId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
