using AutoMapper;
using Inspector.Application.Features.UserFeatures.Queries.GetAllUserQuery;
using Inspector.Domain.Entities;

namespace Inspector.Application.Features.UserFeatures
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<ApplicationUser, UserReadShortDto>();
        }
    }
}
