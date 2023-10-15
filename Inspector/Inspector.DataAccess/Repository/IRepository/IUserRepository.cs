using Inspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.DataAccess.Repository.IRepository
{
	public  interface IUserRepository : IRepository<ApplicationUser>
	{
		void Update(ApplicationUser obj);
		void Save();
	}
}
