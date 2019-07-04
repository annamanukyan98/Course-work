using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
	public class Tickets
	{
		public int ID { get; set; }

		[Required(ErrorMessage = "The Movie name field is required.")]
		[DisplayName("Movie name")]
		public string MovieName { get; set; }

		[Required(ErrorMessage = "The Date field is required.")]
		public DateTime Date { get; set; }

		[Required(ErrorMessage = "The Duration field is required.")]
		public string Duration { get; set; }

		[Required(ErrorMessage = "The Price field is required.")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "The Quantity field is required.")]
		public int Quantity { get; set; }
	}
	public class TicketsList : List<Tickets>
	{
	}
}