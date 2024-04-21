using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class Category
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Meal> Meals { get; set; } = new List<Meal>();
}
