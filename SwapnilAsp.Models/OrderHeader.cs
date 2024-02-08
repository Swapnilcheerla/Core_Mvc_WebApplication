using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SwapnilAsp.Models
{
	public class OrderHeader
	{
		public int Id { get; set; }
		public string ApplicationUserId { get; set; }
		[ForeignKey(nameof(ApplicationUserId))]
		[ValidateNever]
		public ApplicationUser ApplicationUser { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime ShippingDate { get; set; }
		public double OrderTotal { get; set; }

		public String? OrderStatus { get; set; }
		public String? PaymentStatus { get; set; }
		public String? TrackingNumber { get; set; }

		public String? Carrier { get; set; }


		public DateTime PaymentDate { get; set; }
		public DateTime PaymentDueDate { get; set; }

		public string? PaymentIntentId { get; set; }


		[Required]
		public string Name { get; set; }
		[Required]
		public string? StreetAddress { get; set; }
		[Required]
		public string? City { get; set; }
		[Required]
		public string? State { get; set; }
		[Required]
		public string? PostalCode { get; set; }
		[Required]

		public string? PhoneNumber { get; set; }



	}
}
