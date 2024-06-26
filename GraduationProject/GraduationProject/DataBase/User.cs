﻿using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class User
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateTime? BirthDate { get; set; }

    public int? GenderId { get; set; }

    public int? RoleId { get; set; }

    public string? Image { get; set; }

    public byte[]? BinaryImage { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual PersonGender? Gender { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
