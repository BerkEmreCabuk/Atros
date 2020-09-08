using Atros.Common.Enums;
using Atros.Data.Entities;
using Atros.Domain.MovieEvaluations.Models;
using Atros.Domain.Movies.Models;
using Atros.Domain.Users.Models;
using AutoMapper;
using System;

namespace Atros.Domain.Infrastructure.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() : this("AutoMapperProfileMappings")
        {
        }
        public AutoMapperProfile(string profileName) : base(profileName)
        {
            CreateMap<Movie, MoviePagedModel>();
            CreateMap<MoviePagedModel, Movie>();

            CreateMap<Movie, MovieDetailModel>();
            CreateMap<MovieDetailModel, Movie>();

            CreateMap<Movie, MovieModel>();
            CreateMap<MovieModel, Movie>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Status.Active))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();

            CreateMap<MovieEvaluation, MovieEvaluationModel>();
            CreateMap<MovieEvaluationModel, MovieEvaluation>();
        }
    }
}
