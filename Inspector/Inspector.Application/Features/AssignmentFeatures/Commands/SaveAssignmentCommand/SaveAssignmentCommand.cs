﻿using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.AssignmentFeatures.Commands.SaveAssignmentCommand
{
	public record SaveAssignmentCommand() : IRequest<Unit> { }
}
