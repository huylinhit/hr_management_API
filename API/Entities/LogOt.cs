﻿using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class LogOt
{
    public int OtLogId { get; set; }

    public int StaffId { get; set; }

    public int? OtTypeId { get; set; }

    public DateTime LogStart { get; set; }

    public DateTime LogEnd { get; set; }

    public double LogHours { get; set; }

    public int? Amount { get; set; }

    public string? Reason { get; set; }

    public string? Status { get; set; }

    public string? ProcessNote { get; set; }

    public int? RespondencesId { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? ChangeStatusTime { get; set; }

    public bool? Enable { get; set; }

    public virtual OtType? OtType { get; set; }

    public virtual UserInfor Staff { get; set; } = null!;
}
