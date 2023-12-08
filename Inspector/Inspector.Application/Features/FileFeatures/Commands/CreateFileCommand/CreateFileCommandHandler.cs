using Inspector.Application.Repositories;
using MediatR;

namespace Inspector.Application.Features.FileFeatures.Commands.CreateFileCommand
{
	public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, Unit>
	{
		private readonly IFileRepository _fileRepository;
		public CreateFileCommandHandler(IFileRepository fileRepository)
		{
			_fileRepository = fileRepository;
		}

		public async Task<Unit> Handle(CreateFileCommand request, CancellationToken cancellationToken)
		{
			await _fileRepository.CreateAsync(request.file);
			return Unit.Value; 
		}
	}
}
