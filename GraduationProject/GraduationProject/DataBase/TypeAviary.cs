using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class TypeAviary
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Aviary> Aviaries { get; set; } = new List<Aviary>();
}
