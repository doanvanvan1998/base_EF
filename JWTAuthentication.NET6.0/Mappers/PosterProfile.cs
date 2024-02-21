using AutoMapper;
using JWTAuthentication.NET6._0.Models.DTO;
using JWTAuthentication.NET6._0.Models.Entities;
using JWTAuthentication.NET6._0.Models.Models;
using Microsoft.Build.Framework.Profiler;

namespace JWTAuthentication.NET6._0.Mappers
{
    public class PosterProfile : Profile
    {
        public PosterProfile()
        {
            CreateMap<PosterRequest, PosterEntity>();
            CreateMap<PosterEntity, PosterDTO>();
        }
    }
}
