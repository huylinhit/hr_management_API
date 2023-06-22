﻿using API.DTOs.LogLeaveDTO;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class LogLeaveService
    {
        private readonly SwpProjectContext _context;
        private readonly IMapper _mapper;
        private readonly TheCalendarService _theCalendarService;
        private readonly UserInfoService _userInfoService;

        public LogLeaveService(
            SwpProjectContext context,
            IMapper mapper,
            TheCalendarService theCalendarService,
            UserInfoService userInfoService
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _theCalendarService = theCalendarService ?? throw new ArgumentNullException(nameof(theCalendarService));
            _userInfoService = userInfoService ?? throw new ArgumentNullException(nameof(userInfoService));
        }
        public async Task<List<LogLeaveDTO>> GetLogLeaveDTOs()
        {
            var logleaves = await _context.LogLeaves
                                    .Include(c => c.LeaveType)
                                    .ToListAsync();

            var returnLogLeaves = _mapper.Map<List<LogLeaveDTO>>(logleaves);
            return returnLogLeaves;
        }
        public async Task<List<LogLeaveDTO>> GetLogLeavesByStaffId(int staffId)
        {
            var logLeaves = await _context.LogLeaves
                                    .Include(c => c.LeaveType)
                                    .Where(c => c.StaffId == staffId)
                                    .ToListAsync();

            var returnLogLeaves = _mapper.Map<List<LogLeaveDTO>>(logLeaves);
            return returnLogLeaves;
        }

        public async Task<bool> IsLogLeaveExist(int logLeaveId)
        {
            return await _context.LogLeaves.AnyAsync(c => c.LeaveLogId == logLeaveId);
        }
        public async Task<LogLeaveDTO> GetLogLeaveByStaffIdAndLogLeaveId(int staffId, int logLeaveId)
        {
            var LogLeave = await _context.LogLeaves
                                        .Include(c => c.LeaveType)
                                        .Where(c => c.StaffId == staffId && c.LeaveLogId == logLeaveId)
                                        .FirstOrDefaultAsync();
            var returnLogLeave = _mapper.Map<LogLeaveDTO>(LogLeave);
            return returnLogLeave;
        }
        public async Task<UserInfor?> GetUserLogLeave(int staffId)
        {
            return await _context.UserInfors
                                            .Include(c => c.LogLeaves)
                                            .Where(c => c.StaffId == staffId)
                                            .FirstOrDefaultAsync();
        }


    }
}
