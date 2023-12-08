using AutoMapper;
using Inspector.Application.Features.OrganizationFeatures.Queries.GetAllOrganizationQuery;
using Inspector.Domain.Entities;

namespace Inspector.Application.Features.OrganizationFeatures
{
	public sealed class OrganizationMapper : Profile
	{
		public OrganizationMapper()
		{
			CreateMap<Organization, OrganizationReadShortDto>();
		}
	}
}
