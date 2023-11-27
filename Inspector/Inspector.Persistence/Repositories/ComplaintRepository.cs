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
	public class ComplaintRepository : BaseRepository<Complaint>, IComplaintRepository
	{
		protected readonly ApplicationDbContext Context;

		public ComplaintRepository(ApplicationDbContext context) : base(context)
		{
			Context = context;
		}
		public Task<IEnumerable<Complaint>> FindComplaintPartAsync(string text)
		{
			throw new NotImplementedException();
		}
	}
}
