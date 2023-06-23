using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using SalesWebMvc.Services;
using SalesWebMvc.Filters;

namespace SalesWebMvc.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RegistroVendasController : Controller
    {

        private readonly RegistroVendasService _registroVendasService;

        public RegistroVendasController(RegistroVendasService registroVendasService)
        {
            _registroVendasService = registroVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _registroVendasService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _registroVendasService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}
