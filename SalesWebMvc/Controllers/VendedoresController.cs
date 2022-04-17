using SalesWebMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace SalesWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedoresServices _vendedoresServices;

        public VendedoresController(VendedoresServices vendedoresServices)
        {
            _vendedoresServices = vendedoresServices;
        }
        public IActionResult Index()
        {
            var list = _vendedoresServices.FindAll();
            return View(list);
        }
    }
}
