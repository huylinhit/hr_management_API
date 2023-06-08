﻿using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public int? ManagerId { get; set; }

    public virtual UserInfor? Manager { get; set; }

    public virtual ICollection<UserInfor> UserInfors { get; set; } = new List<UserInfor>();
}
