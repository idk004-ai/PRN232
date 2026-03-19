using AutoMapper;
using BusinessObjects.Models.DTOs.Report;
using BusinessObjects.Models.Entities;
using DataAccessObjects;

namespace ProductWebAPI.Mappers;
public class ReportResolver(ApplicationDBContext dBContext) : IValueResolver<ReportDTO, Report, ApplicationUser>
{
    private readonly ApplicationDBContext _dbContext = dBContext;

    public ApplicationUser Resolve(ReportDTO source, Report destination, ApplicationUser destMember, ResolutionContext context)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Email == source.Creater)
            ?? throw new Exception("User not found");
        return user;
    }
}