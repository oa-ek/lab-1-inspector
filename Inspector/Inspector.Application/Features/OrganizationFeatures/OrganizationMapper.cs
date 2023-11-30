using AutoMapper;
using Inspector.Application.Features.ComplaintFeatures.Commands.CreateComplaint;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;
using Inspector.Application.Features.OrganizationFeatures.Queries.AddAllOrganizationQuery;
using Inspector.Domain.Entities;
using System.Collections.Generic;

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
