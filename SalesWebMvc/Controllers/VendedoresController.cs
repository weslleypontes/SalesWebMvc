using SalesWebMvc.Services;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
namespace SalesWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedoresServices _vendedoresServices;
        private readonly DepartmentService _departmentService;

        public VendedoresController(VendedoresServices vendedoresServices, DepartmentService departmentService)
        {
            _vendedoresServices = vendedoresServices;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var list = _vendedoresServices.FindAll();
            return View(list);
        }

        // IActionResult é o tipo de retorno de todas as ações
        public IActionResult Create()
        {
            //carregar os deparrtamentos
            var departments = _departmentService.FindAll();
            //instanciar o objeto do nosso View Model
            var viewModel = new VendedorFormViewModel { Departments = departments };
            return View(viewModel);
        }


        //tenho que indicar que essa ação aqui ela vai ser uma ação de post 
        [HttpPost]
        //uar outra anotação para prevenir que a minha aplicação sofra ataques CSRF
        [ValidateAntiForgeryToken]
        //no caso dessa operação Create ela vai reveber  o objeto vendedor que veio na requisição
        // para receber o objeto da requisição instanciar esse vendededor
        // basta vc colocar ele aqui como  parametro o framework já faz isso pra gente
        public IActionResult Create(Vendedores vendedores)
        {
            _vendedoresServices.Insert(vendedores);
            //feito isso vamos mostrar novamente a tela principal do meu   crud de vendedores
            // usar o Name of para melhora a manutenção do meu sistema poeqie se amanha eu mudar o mone, não vou precisar mudar 
            // nada no nameof
            return RedirectToAction(nameof(Index));
        }
    }
}
