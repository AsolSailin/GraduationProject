using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class Kid
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public DateTime? BirthDate { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
