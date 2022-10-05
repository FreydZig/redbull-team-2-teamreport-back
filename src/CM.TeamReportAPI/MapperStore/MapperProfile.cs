using AutoMapper;
using CM.TeamReportAPI.Models;
using CM.TeamRepots.DataLayer.Entity;

namespace CM.TeamReportAPI.MapperStore
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserCreateModel, Users>();
            CreateMap<ReportFormBody, Reports>();
        }
    }
}
