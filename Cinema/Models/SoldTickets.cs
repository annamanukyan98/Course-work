using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
	public class SoldTickets
	{
		public string MovieName { get; set; }

		public decimal TotalAmount { get; set; }

		public int Quantity { get; set; }

		public string FirstName { get; set; }

		public string PhoneNumber { get; set; }

		public string eMail { get; set; }

		public string CardNumber { get; set; }

		public string Comments { get; set; }
	}
}