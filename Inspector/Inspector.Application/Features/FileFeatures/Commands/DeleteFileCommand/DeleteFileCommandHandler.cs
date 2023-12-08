using Inspector.Application.Repositories;
using MediatR;

namespace Inspector.Application.Features.FileFeatures.Commands.DeleteFileCommand
{
	public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, Unit>
	{
		private readonly IFileRepository _fileRepository;
		public DeleteFileCommandHandler(IFileRepository fileRepository)
		{
			_fileRepository = fileRepository;
		}

		public async Task<Unit> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
		{
			await _fileRepository.DeleteAsync(request.file);
			return Unit.Value;
		}
	}
}
