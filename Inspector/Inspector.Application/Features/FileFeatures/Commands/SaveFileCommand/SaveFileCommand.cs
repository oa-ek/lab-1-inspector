﻿using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.FileFeatures.Commands.SaveFileCommand
{
	public record SaveFileCommand() : IRequest<Unit> { }
}