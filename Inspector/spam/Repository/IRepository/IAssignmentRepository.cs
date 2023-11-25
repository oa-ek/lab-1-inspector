using Inspector.Domain.Entities;
using Inspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Domain.Repository.IRepository
{
    public interface IAssignmentRepository : IRepository<Assignment>
    {
        void Update(Assignment obj);
        void Save();
    }
}
