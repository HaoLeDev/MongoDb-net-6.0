using Application.Model.Models;
using Application.Model.ViewModels;
using AutoMapper;

namespace MongoDbRealtimeDatabase.Api.Infrastructure.Extentsions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Test, PersonInformationViewModel>().ReverseMap();
            
        }
    }
}
