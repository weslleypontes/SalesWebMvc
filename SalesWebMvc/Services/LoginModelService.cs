using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class LoginModelService
    {
        private readonly SalesWebMvcContext _context;

        public LoginModelService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public Vendedores BuscarPorNome(string nome)
        {
            return _context.Vendedores.FirstOrDefault(x => x.Nome.ToUpper() == nome.ToUpper());
        }
    }
}
