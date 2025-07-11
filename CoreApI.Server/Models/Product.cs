﻿using System;
using System.Collections.Generic;

namespace CoreApI.Server.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int? CategoryId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Category? Category { get; set; }
}
