using SalesWebMvc.Services;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using System.Collections.Generic;
using SalesWebMvc.Services.Exceptions;
using System.Diagnostics;
using System.Threading.Tasks;
using SalesWebMvc.Filters;

namespace SalesWebMvc.Controllers
    
{
    [PaginaParaUsuarioLogado]
    public class VendedoresController : Controller
    {
        private readonly VendedoresServices _vendedoresServices;
        private readonly DepartmentService _departmentService;

        public VendedoresController(VendedoresServices vendedoresServices, DepartmentService departmentService)
        {
            _vendedoresServices = vendedoresServices;
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _vendedoresServices.FindAllAsync();
            return View(list);
        }

        // IActionResult é o tipo de retorno de todas as ações
        public async Task<IActionResult> Create()
        {
            //carregar os departamentos
            var departments = await _departmentService.FindAllAsync();
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
        public async Task<IActionResult> Create(Vendedores vendedores)
        {
            //teste para testar se o medelo foi validado
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new VendedorFormViewModel { Vendedores = vendedores, Departments = departments };
                return View(viewModel);
            }
            await _vendedoresServices.InsertAsync(vendedores);
            //feito isso vamos mostrar novamente a tela principal do meu   crud de vendedores
            // usar o Name of para melhora a manutenção do meu sistema poeqie se amanha eu mudar o mone, não vou precisar mudar 
            // nada no nameof
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            //pegar esse objeto que eu estou mandando deletar
            var obj = await _vendedoresServices.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _vendedoresServices.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
                
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            //pegar esse objeto que eu estou mandando deletar
            var obj = await _vendedoresServices.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _vendedoresServices.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            List<Department> departments = await _departmentService.FindAllAsync();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedores = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedores vendedores)
        {
            //teste para testar se o medelo foi validado
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new VendedorFormViewModel {Vendedores = vendedores, Departments = departments };
                return View(viewModel);
            }
            if (id != vendedores.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _vendedoresServices.UpdateAsync(vendedores);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
