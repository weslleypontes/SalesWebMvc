
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using System;

namespace SalesWebMvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginModelService _loginModelService;

        public LoginController(LoginModelService loginModelService)
        {
            _loginModelService = loginModelService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var user = _loginModelService.BuscarPorNome(loginModel.Login);

                    if(user != null)
                    {
                        if (user.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"A senha do usuário é inválida, tente novamente.";
                        }

                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor tente novamente.";

                    }

                }
                return View("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction(nameof(Index));
            }


        }
    }  
}
