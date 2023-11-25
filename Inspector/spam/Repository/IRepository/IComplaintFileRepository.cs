using Inspector.Domain.Entities;
using Inspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Domain.Repository.IRepository
{
    public interface IComplaintFileRepository : IRepository<ComplaintFile>
    {
        void Update(ComplaintFile complaintFile);
        void Save();
    }
}
