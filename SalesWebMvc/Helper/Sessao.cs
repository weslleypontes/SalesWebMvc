using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SalesWebMvc.Models;

namespace SalesWebMvc.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor;
        }
        public Vendedores BuscarSessaoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
            //Se a sessao do usuario estiver vazia retonar nulo
            if (string.IsNullOrEmpty(sessaoUsuario) != null) return null;

            return JsonConvert.DeserializeObject<Vendedores>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(Vendedores vendedores)
        {
            string valor = JsonConvert.SerializeObject(vendedores);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
