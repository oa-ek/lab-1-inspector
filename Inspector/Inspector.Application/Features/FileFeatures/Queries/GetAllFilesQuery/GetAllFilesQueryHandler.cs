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

namespace Inspector.Application.Features.FileFeatures.Queries.GetAllFilesQuery
{
	public class GetAllFilesQueryHandler : IRequestHandler<GetAllFilesQuery, IEnumerable<ComplaintFile>>
	{
		private readonly IFileRepository _fileRepository;
		private readonly IMapper _mapper;
		public GetAllFilesQueryHandler(IFileRepository fileRepository, IMapper mapper)
		{
			_mapper = mapper;
			_fileRepository = fileRepository;
		}

		public async Task<IEnumerable<ComplaintFile>> Handle(GetAllFilesQuery request, CancellationToken cancellationToken)
		{
			await Task.CompletedTask;
			return _mapper.Map<IEnumerable<ComplaintFile>, IEnumerable<ComplaintFile>>(await _fileRepository.GetAllAsync());
		}
	}
}
