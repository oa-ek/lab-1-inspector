using Inspector.Application.Repositories;
using MediatR;

namespace Inspector.Application.Features.ResponseFeatures.Commands.CreateResponseCommand
{
	public class CreateResponseCommandHandler : IRequestHandler<CreateResponseCommand, Unit>
	{
		private readonly IResponseRepository _responseRepository;
		public CreateResponseCommandHandler(IResponseRepository responseRepository)
		{
            _responseRepository = responseRepository;
		}

		public async Task<Unit> Handle(CreateResponseCommand request, CancellationToken cancellationToken)
		{
			await _responseRepository.CreateAsync(request.response);
			return Unit.Value; 
		}
	}
}
