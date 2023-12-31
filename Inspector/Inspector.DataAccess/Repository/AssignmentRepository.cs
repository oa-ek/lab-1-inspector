﻿using Inspector.DataAccess.Data;
using Inspector.DataAccess.Repository.IRepository;
using Inspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.DataAccess.Repository
{
	public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
	{
		private readonly ApplicationDbContext _db;
		public AssignmentRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		public void Save()
		{
			_db.SaveChanges();
		}

		public void Update(Assignment obj)
		{
			_db.Update(obj);
		}
	}
}
