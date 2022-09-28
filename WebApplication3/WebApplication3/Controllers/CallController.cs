using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CallController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> calling(string phone)
        {
            ViewBag.phone = phone;
            return View();
        }

        [NonAction]
        private string Details(int id)
        {
            return "asdasd";
        }
    }
}
