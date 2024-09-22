using AutoMapper;
using minimalAPI.DTOs;
using minimalAPI.Models;

namespace minimalAPI.Utilities
{
    public class AutomapperProfiles :Profile
    {
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<Genre, GenreDTO>();
                CreateMap<CreateGenreDTO, Genre>();
            }
        }
    }
}
