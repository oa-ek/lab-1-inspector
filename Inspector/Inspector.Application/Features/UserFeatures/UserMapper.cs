using AutoMapper;
using Inspector.Application.Features.UserFeatures.Queries.AddAllUserQuery;
using Inspector.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
