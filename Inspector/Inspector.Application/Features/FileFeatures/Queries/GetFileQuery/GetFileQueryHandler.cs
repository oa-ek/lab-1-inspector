using AutoMapper;
using Inspector.Application.Repositories;
using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.FileFeatures.Queries.GetFileQuery
{
	public class GetFileQueryHandler : IRequestHandler<GetFileQuery, ComplaintFile>
	{
		private readonly IFileRepository _fileRepository;
		private readonly IMapper _mapper;
		public GetFileQueryHandler(IFileRepository fileRepository, IMapper mapper)
		{
			_mapper = mapper;
            _fileRepository = fileRepository;
		}

		public async Task<ComplaintFile> Handle(GetFileQuery request, CancellationToken cancellationToken)
		{
			return await Task.FromResult(_mapper.Map<ComplaintFile, ComplaintFile>(await _fileRepository.GetAsync(request.id, request.includeProperties)));
		}

	}
}
