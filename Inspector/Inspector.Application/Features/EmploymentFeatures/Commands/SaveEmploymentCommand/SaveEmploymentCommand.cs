using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.EmploymentFeatures.Commands.SaveEmploymentCommand
{
	public record SaveEmploymentCommand() : IRequest<Unit> { }
}
