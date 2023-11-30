using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Models
{
	public class ComplaintFile
	{
		public int Id { get; set; }
		public string FileName { get; set; }
		public string FilePath { get; set; }

		[ForeignKey(nameof(Complaint))]
		public int ComplaintId { get; set; }
		public Complaint Complaint { get; set; }
	}

}
