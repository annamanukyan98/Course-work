using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
	public class TicketsSale
	{
		public int ID { get; set; }

		[DisplayName("Movie name")]
		public string MovieName { get; set; }

		public decimal Price { get; set; }

		[DisplayName("Total amount")]
		public decimal TotalAmount { get; set; }

		public int Quantity { get; set; }

		[Required(ErrorMessage = "The First name field is required.")]
		[DisplayName("First name")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "The Phone number fielf is required.")]
		[DisplayName("Phone number")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "The Email field is required.")]
		[DisplayName("Email")]
		public string eMail { get; set; }

		[Required(ErrorMessage = "The Card number field is required.")]
		[DisplayName("Card number")]
		public string CardNumber { get; set; }

		public string Comments { get; set; }
	}
}