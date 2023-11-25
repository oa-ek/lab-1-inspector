using AutoMapper;
using Inspector.Application.Features.ComplaintFeatures.Commands.CreateComplaint;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;
using Inspector.Domain.Entities;

namespace Inspector.Application.Features.ComplaintFeatures
{
    public sealed class ComplainrMapper : Profile
    {
        public ComplainrMapper() 
        {
            CreateMap<Complaint, ComplaintReadDto>();
                //.ForMember(dest => dest.Owner, act => act.MapFrom(src => src.Owner));

            CreateMap<Complaint, ComplaintReadShortDto>();
        }

    }
}
