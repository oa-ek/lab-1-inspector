using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Inspector.Models.ViewModels;
using System.IO.Compression;

namespace Inspector.Models
{
	public class Assignment
	{
		public Assignment()
		{
			CreatedDate = DateTime.Now;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		// Зовнішні ключі для зв'язку з таблицею "user"
		public string? UserGiveId { get; set; }
		public string UserTakeId { get; set; }

		// Зовнішні ключі для зв'язку з таблицею "Complaint"
		public int ComplaintId { get; set; }

		public DateTime CreatedDate { get; set; }

		// Навігаційні властивості для зв'язку з таблицею "user"
		[ForeignKey("UserGiveId")]
		[ValidateNever]
		public ApplicationUser UserGive { get; set; }

		[ForeignKey("UserTakeId")]
		[ValidateNever]
		public ApplicationUser UserTake { get; set; }

		// Навігаційна властивість для зв'язку з таблицею "Complaint"
		[ForeignKey("ComplaintId")]
		[ValidateNever]
		public Complaint Complaint { get; set; }
	}

}
