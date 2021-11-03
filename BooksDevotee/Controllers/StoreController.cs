using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksDevotee.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class StoreController : Controller
    {
        public IActionResult OrderList()
        {
            return View();
        }
    }
}
