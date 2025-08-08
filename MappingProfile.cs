using Adingisa.Dtos;
using Adingisa.Models;
using AutoMapper;

namespace Adingisa
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role != null ? src.Role.RoleName : "Unknown"));
            CreateMap<UserCreateDto, User>();
            CreateMap<CommentCreateDto, Comment>();
            CreateMap<RoleCreateDto, Role>();
            CreateMap<ReplyCreateDto, Reply>();
            CreateMap<PostCreateDto, Post>();
            CreateMap<TaxiLocationCreateDto, TaxiLocation>();
            CreateMap<TaxiLocationUpdateDto, TaxiLocation>();
            CreateMap<TaxiLocation, TaxiLocationReadDto>();
        }
    }
}