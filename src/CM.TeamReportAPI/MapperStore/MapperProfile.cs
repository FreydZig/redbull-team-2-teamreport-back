using AutoMapper;
using CM.TeamReport.Domain.Models;
using CM.TeamReportAPI.Models;
using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamReportAPI.MapperStore
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserCreateModel, Users>();
            CreateMap<InviteMemberModel, InviteMember>();
            CreateMap<ReportFormBody, Reports>();

        }
    }
}
