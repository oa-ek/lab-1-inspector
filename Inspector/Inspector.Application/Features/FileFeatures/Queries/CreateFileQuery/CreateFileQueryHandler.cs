using AutoMapper;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddComplaintQuery;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.ComplaintFeatures.Queries.CreateFileQuery
{
	public class CreateFileQueryHandler : IRequestHandler<CreateFileQuery, Unit>
	{
		private readonly IFileRepository _fileRepository;
		public CreateFileQueryHandler(IFileRepository fileRepository)
		{
			_fileRepository = fileRepository;
		}

		public async Task<Unit> Handle(CreateFileQuery request, CancellationToken cancellationToken)
		{
			await _fileRepository.CreateAsync(request.file);
			return Unit.Value; 
		}
	}
}
