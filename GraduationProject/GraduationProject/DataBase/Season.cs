using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class Season
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<SeasonMethod> SeasonMethods { get; set; } = new List<SeasonMethod>();
}
