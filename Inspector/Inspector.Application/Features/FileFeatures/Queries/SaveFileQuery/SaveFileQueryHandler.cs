using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.FileFeatures.Queries.SaveFileQuery
{
	public class SaveFileQueryHandler : IRequestHandler<SaveFileQuery, Unit>
	{
		private readonly IFileRepository _fileRepository;
		public SaveFileQueryHandler(IFileRepository fileRepository)
		{
			_fileRepository = fileRepository;
		}

		public async Task<Unit> Handle(SaveFileQuery request, CancellationToken cancellationToken)
		{
			await _fileRepository.SaveAsync();
			return Unit.Value;
		}
	}
}
