using Inspector.Application.Repositories;
using Inspector.Domain.Common;
using Inspector.Domain.Data;
using Inspector.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Persistence.Repositories
{
	public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
	{
		protected readonly ApplicationDbContext Context;

		public AssignmentRepository(ApplicationDbContext context) : base(context)
		{
			Context = context;
		}
	}
}
