using Cinema.BusinessLogic;
using Cinema.Models;
using System.Web.Mvc;

namespace Cinema.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult MovieInsertion()
		{
			return View();
		}

		[HttpPost]
		public ActionResult MovieInsertion(Tickets item)
		{
			Manager manager = new Manager();
			manager.InsertMovie(item);
			return RedirectToAction("Tickets");
		}

		[HttpGet]
		public ActionResult Tickets()
		{
			Manager manager = new Manager();
			return View(manager.SelectItems());
		}

		[HttpGet]
		public ActionResult BuyTicketModal(int id)
		{
			Manager manager = new Manager();
			TicketsSale item = manager.GetByID(id);
			return PartialView("~/Views/Shared/_BuyTicket.cshtml", item);
		}

		[HttpPost]
		public ActionResult BuyTicket(TicketsSale item)
		{
			Manager manager = new Manager();

			manager.SetSoldItems(item);
			return RedirectToAction("Tickets");
		}

		public decimal TotalAmount(int id, int selectedVal)
		{
			Manager manager = new Manager();
			TicketsSale item = manager.GetByID(id);
			decimal amount = item.Price * selectedVal;
			return amount;
		}

	}
}