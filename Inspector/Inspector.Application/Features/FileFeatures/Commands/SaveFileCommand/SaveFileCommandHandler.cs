using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.FileFeatures.Commands.SaveFileCommand
{
	public class SaveFileCommandHandler : IRequestHandler<SaveFileCommand, Unit>
	{
		private readonly IFileRepository _fileRepository;
		public SaveFileCommandHandler(IFileRepository fileRepository)
		{
			_fileRepository = fileRepository;
		}

		public async Task<Unit> Handle(SaveFileCommand request, CancellationToken cancellationToken)
		{
			await _fileRepository.SaveAsync();
			return Unit.Value;
		}
	}
}
