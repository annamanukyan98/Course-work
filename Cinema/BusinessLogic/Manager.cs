using Cinema.Models;
using System;
using System.Data.SqlClient;

namespace Cinema.BusinessLogic
{
	public class Manager
	{
		string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

		string selectCommandStr = @"
			SELECT
				A.ID, MovieName, Date, Duration, Price, ISNULL( A.Quantity - B.QuantitySum, A.Quantity) AS Quantity
				
			FROM Tickets AS A LEFT JOIN
				(
					SELECT
						MovieID,
						Sum(Quantity) AS QuantitySum
					FROM SoldTickets
					GROUP BY MovieID
				) AS B
				ON A.ID = B.MovieID 
		";

		public void InsertMovie(Tickets item)
		{
			string commandStr = $@"
				INSERT
				INTO Tickets
				VALUES
						(
							'{item.MovieName}',
							'{item.Date}',
							'{item.Duration}',
							'{item.Price}',
							'{item.Quantity}'
						)";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(commandStr, connection))
				{
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

		public TicketsList SelectItems()
		{
			TicketsList list = new TicketsList();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(selectCommandStr, connection))
				{
					connection.Open();

					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						Tickets item = new Tickets();
						item.ID = Convert.ToInt32(reader["ID"]);
						item.MovieName = Convert.ToString(reader["MovieName"]);
						item.Date = Convert.ToDateTime(reader["Date"]);
						item.Duration = Convert.ToString(reader["Duration"]);
						item.Price = Convert.ToDecimal(reader["Price"]);
						item.Quantity = Convert.ToInt32(reader["Quantity"]);
						list.Add(item);
					}

				}
			}
			return list;
		}

		public TicketsSale GetByID(int ID)
		{
			string commandStr = $"{selectCommandStr} WHERE ID = {ID}";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(commandStr, connection))
				{
					connection.Open();

					TicketsSale item = new TicketsSale();
					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						item.ID = ID;
						item.MovieName = Convert.ToString(reader["MovieName"]);
						item.Price = Convert.ToDecimal(reader["Price"]);
						item.Quantity = Convert.ToInt32(reader["Quantity"]);
						item.TotalAmount = item.Price * item.Quantity;
					}

					return item;
				}
			}

		}

		public void SetSoldItems(TicketsSale item)
		{
			string commandStr = $@"
				INSERT 
				INTO SoldTickets(MovieID, Quantity, Amount, FirstName, PhoneNumber, eMail, CardNumber, Comments)
				VALUES
						(
							'{item.ID}',
							'{item.Quantity}',
							'{item.TotalAmount}',
							'{item.FirstName}',
							'{item.PhoneNumber}',
							'{item.eMail}',
							'{item.CardNumber}',
							'{item.Comments}'
						)";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(commandStr, connection))
				{
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}
	}
}