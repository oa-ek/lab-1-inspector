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
	public class EmploymentRepository : Repository<Employment>, IEmploymentRepository
	{
		private readonly ApplicationDbContext _db;
		public EmploymentRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		public void Save()
		{
			_db.SaveChanges();
		}

		public void Update(Employment employment)
		{
			_db.Update(employment);
		}
	}
}
