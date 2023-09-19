using Inspector.DataAccess.Data;
using Inspector.DataAccess.Repository.IRepository;
using Inspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.DataAccess.Repository
{
	public class ComplaintRepository : Repository<Complaint>, IComplaintRepository
	{
		private readonly ApplicationDbContext _db;
		public ComplaintRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		public void Save()
		{
			_db.SaveChanges();
		}

		public void Update(Complaint complaint)
		{
			_db.Update(complaint);
		}
	}
}
