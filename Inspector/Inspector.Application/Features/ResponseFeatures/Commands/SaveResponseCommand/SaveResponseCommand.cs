﻿using Inspector.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.CommandFeatures.Commands.SaveResponseCommand
{
	public record SaveResponseCommand() : IRequest<Unit> { }
}