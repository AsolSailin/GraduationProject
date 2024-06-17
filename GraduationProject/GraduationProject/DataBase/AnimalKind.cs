using System;
using System.Collections.Generic;
using GraduationProject.DataBase;

namespace GraduationProject;

public partial class AnimalKind
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Aviary> Aviaries { get; set; } = new List<Aviary>();
}
