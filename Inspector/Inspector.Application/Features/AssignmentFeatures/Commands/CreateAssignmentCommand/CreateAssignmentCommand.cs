﻿using Inspector.Application.Features.ComplaintFeatures.Queries.AddAllComplaintQuery;
using Inspector.Domain.Entities;
using Inspector.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Application.Features.AssignmentFeatures.Commands.CreateAssignmentCommand
{
	public record CreateAssignmentCommand(Assignment assignment) : IRequest<Unit> { }
}