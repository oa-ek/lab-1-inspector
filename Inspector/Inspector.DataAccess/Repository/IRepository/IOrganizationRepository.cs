using Inspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.DataAccess.Repository.IRepository
{
	public  interface IOrganizationRepository : IRepository<Organization>
	{
		void Update(Organization obj);
		void Save();
	}
}
