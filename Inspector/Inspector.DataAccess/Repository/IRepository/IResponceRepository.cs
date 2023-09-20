using Inspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.DataAccess.Repository.IRepository
{
	public  interface IResponceRepository : IRepository<Responce>
	{
		void Update(Responce obj);
		void Save();
	}
}
