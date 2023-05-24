using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesWebMvc.Models;
using System.Threading.Tasks;

namespace SalesWebMvc.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            Vendedores user = JsonConvert.DeserializeObject<Vendedores>(sessaoUsuario);

            return View(user);
        }
    }
}
