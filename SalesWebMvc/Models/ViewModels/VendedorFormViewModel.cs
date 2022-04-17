using System.Collections.Generic;

namespace SalesWebMvc.Models.ViewModels
{
    public class VendedorFormViewModel
    {
        // quais vao ser os dados nesessarios para uma tela de cadastro de vendedor 
        public Vendedores Vendedores { get; set; }
        //vou precisar tbm uma lista de departamentos
        public ICollection<Department> Departments { get; set; }
    }
}
