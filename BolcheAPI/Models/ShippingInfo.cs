﻿using System;
using System.Collections.Generic;

namespace BolcheAPI.Models;

public partial class ShippingInfo
{
    public int ShippingInfoId { get; set; }

    public string Address { get; set; } = null!;

    public int PostCode { get; set; }

    public string City { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
