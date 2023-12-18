using Inspector.Domain.Entities;
using MediatR;

namespace Inspector.Application.Features.EmploymentFeatures.Commands.DeleteEmploymentCommand
{
	public record DeleteEmploymentCommand(Employment employee) : IRequest<Employment> { }
}
