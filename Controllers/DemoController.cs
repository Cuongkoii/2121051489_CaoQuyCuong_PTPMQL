using Microsoft.AspNetCore.Mvc;

namespace ptpmql.Controllers
{
    public class DemoController : Controller
    {
        // Hiển thị form
        public IActionResult Index()
        {
            return View();
        }

        // Nhận dữ liệu từ form
        [HttpPost]
        public IActionResult Index(string hoTen)
        {
            ViewBag.Message = "Xin chào " + hoTen;
            return View();
        }
    }
}