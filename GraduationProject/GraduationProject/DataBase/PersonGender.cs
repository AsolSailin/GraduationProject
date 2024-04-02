using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class PersonGender
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
