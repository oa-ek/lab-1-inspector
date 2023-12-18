using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.ResponseFeatures.Commands.UpdateResponseCommand
{
	public class UpdateResponseCommandHandler : IRequestHandler<UpdateResponseCommand, Response>
	{
		private readonly IResponseRepository _responseRepository;
		public UpdateResponseCommandHandler(IResponseRepository responseRepository)
		{
			_responseRepository = responseRepository;
		}

		public async Task<Response> Handle(UpdateResponseCommand request, CancellationToken cancellationToken)
		{
			await _responseRepository.UpdateAsync(request.response);
			return request.response; 
		}
	}
}
