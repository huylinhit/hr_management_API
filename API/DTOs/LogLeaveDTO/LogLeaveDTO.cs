using API.DTOs.UserInforDTO;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.LogLeaveDTO
{
    public class LogLeaveDTO
    {
        public int LeaveLogId { get; set; }

        public int StaffId { get; set; }

        public int? LeaveTypeId { get; set; }

        public DateTime LeaveStart { get; set; }

        public DateTime LeaveEnd { get; set; }

        public double? LeaveDays { get; set; }

        public int? LeaveHours { get; set; }

        public string? Description { get; set; }

        public string? Status { get; set; }

        public DateTime CreateAt { get; set; }

        public string? ProcessNote { get; set; }

        public int? RespondencesId { get; set; }

        public DateTime? ChangeStatusTime { get; set; }

        public bool? Enable { get; set; }

        public virtual LeaveTypeDTO? LeaveType { get; set; }

        public virtual UserInforDto Staff { get; set; } = null!;

    }
}