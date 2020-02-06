using AutoMapper;
using Blend.IT.AppService.ViewModels;
using Blend.IT.Domain.Models;

namespace Blend.IT.AppService.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<UserProfile, UserProfileViewModel>().ReverseMap();
            CreateMap<Teacher, TeacherViewModel>().ReverseMap();
            CreateMap<Student, StudentViewModel>().ReverseMap();
        }
    }
}
