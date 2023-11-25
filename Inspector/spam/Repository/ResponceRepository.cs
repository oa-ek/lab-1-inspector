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
    public class ResponceRepository : Repository<Responce>, IResponceRepository
    {
        private readonly ApplicationDbContext _db;
        public ResponceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Responce obj)
        {
            _db.Update(obj);
        }
    }
}
