using System;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class VendedoresServices
    {

        private readonly SalesWebMvcContext _context;

        public VendedoresServices(SalesWebMvcContext context)
        {
            _context = context;
        }
         
        public List<Vendedores> FindAll()
        {
            return _context.Vendedores.ToList();
        }
        //metodo para inseir um novo cadastro
        public void Insert(Vendedores obj)
        {
            //para inserir
            _context.Add(obj);
            //para confirmar 
            _context.SaveChanges();
        }
    }
}
