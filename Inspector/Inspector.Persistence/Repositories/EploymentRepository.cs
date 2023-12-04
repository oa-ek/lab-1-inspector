﻿using Inspector.Application.Repositories;
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
	public class EmploymentRepository : BaseRepository<Employment>, IEmploymentRepository
	{
		protected readonly ApplicationDbContext Context;

		public EmploymentRepository(ApplicationDbContext context) : base(context)
		{
			Context = context;
		}
	}
}
