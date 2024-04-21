using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class Meal
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? Cost { get; set; }

    public string? Description { get; set; }

    public int? WeightInGram { get; set; }

    public string? ImagePath { get; set; }

    public byte[]? BinaryImage { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CategoryId { get; set; }

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<MealOrder> MealOrders { get; set; } = new List<MealOrder>();
}
