using Inspector.Domain.Data;
using Inspector.Domain.Entities;
using Inspector.Domain.Repository.IRepository;
using Inspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Domain.Repository
{
    public class ComplaintFileRepository : Repository<ComplaintFile>, IComplaintFileRepository
    {
        private readonly ApplicationDbContext _db;
        public ComplaintFileRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ComplaintFile complaintFile)
        {
            _db.Update(complaintFile);
        }
    }
}
