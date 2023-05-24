using SalesWebMvc.Models;
namespace SalesWebMvc.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Vendedores vendedores);

        void RemoverSessaoDoUsuario();

        Vendedores BuscarSessaoUsuario();
    }
}
