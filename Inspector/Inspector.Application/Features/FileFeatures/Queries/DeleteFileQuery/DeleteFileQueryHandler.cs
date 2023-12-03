using AutoMapper;
using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.FileFeatures.Queries.DeleteFileQuery
{
	public class DeleteFileQueryHandler : IRequestHandler<DeleteFileQuery, Unit>
	{
		private readonly IFileRepository _fileRepository;
		public DeleteFileQueryHandler(IFileRepository fileRepository)
		{
			_fileRepository = fileRepository;
		}

		public async Task<Unit> Handle(DeleteFileQuery request, CancellationToken cancellationToken)
		{
			await _fileRepository.DeleteAsync(request.file);
			return Unit.Value;
		}
	}
}
