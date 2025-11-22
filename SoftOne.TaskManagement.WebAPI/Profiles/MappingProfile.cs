using AutoMapper;

namespace SoftOne.TaskManagement.WebAPI.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Auth.User, Entities._Dtos.User.UserResponseDto>();
            CreateMap<Entities._Dtos.User.UserResponseDto, Entities.Auth.User>();
            CreateMap<Entities._Dtos.Auth.UserRegisterDto, Entities.Auth.User>();
            CreateMap<Entities.Auth.User, Entities._Dtos.Auth.UserRegisterDto>();
        }
    }
}
