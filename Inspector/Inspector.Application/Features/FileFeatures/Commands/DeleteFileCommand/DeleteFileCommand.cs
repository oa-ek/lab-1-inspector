using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.FileFeatures.Commands.DeleteFileCommand
{
	public record DeleteFileCommand(ComplaintFile file) : IRequest<Unit> { }
}
