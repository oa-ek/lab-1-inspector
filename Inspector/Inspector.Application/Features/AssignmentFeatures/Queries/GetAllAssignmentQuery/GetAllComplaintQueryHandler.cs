using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.AssignmentFeatures.Queries.GetAllAssignmentQuery
{
    public class GetAllAssignmentQueryHandler : IRequestHandler<GetAllAssignmentQuery, IEnumerable<Assignment>>
    {
        private readonly IAssignmentRepository _assignmentRepository;
        public GetAllAssignmentQueryHandler(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<IEnumerable<Assignment>> Handle(GetAllAssignmentQuery request, CancellationToken cancellationToken)
        {  
            await Task.CompletedTask;
            return await _assignmentRepository.GetAllAsync(request.includeProperties);

        }
    }
}
