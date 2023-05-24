
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Helper;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using System;

namespace SalesWebMvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginModelService _loginModelService;
        private readonly ISessao _sessao;

        public LoginController(LoginModelService loginModelService,
                               ISessao sessao)
        {
            _loginModelService = loginModelService;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            // Se usuario estiver Logado, redirecionar para home
            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
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
                            _sessao.CriarSessaoDoUsuario(user);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"A senha do usuário é inválida.";
                            TempData["MensagemErr"] = $"Tente novamente.";
                            return RedirectToAction(nameof(Index));
                        }

                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s).";
                        TempData["MensagemErr"] = $"Por favor tente novamente.";
                        return RedirectToAction(nameof(Index));
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
