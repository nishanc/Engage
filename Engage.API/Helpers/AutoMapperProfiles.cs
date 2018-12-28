using System.Linq;
using AutoMapper;
using Engage.API.Dtos;
using Engage.API.Models;

namespace Engage.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserForListDto>()
            .ForMember(dest => dest.PhotoUrl, opts => {
                opts.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            })
            .ForMember(dest => dest.Age, opts => {
                opts.ResolveUsing(d => d.DateOfBirth.CalculateAge());
            });

            CreateMap<User,UserForDetailedDto>()
            .ForMember(dest => dest.PhotoUrl, opts => {
                opts.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            })
            .ForMember(dest => dest.Age, opts => {
                opts.ResolveUsing(d => d.DateOfBirth.CalculateAge());
            });
            
            CreateMap<Photo,PhotosForDetailedDto>();  

            CreateMap<UserForUpdateDto, User>();

            CreateMap<PhotoForCreationDto, Photo>();

            CreateMap<Photo, PhotoForReturnDto>();
        }
    }
}