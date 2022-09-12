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
            //pegar o primeiro elemento do banco de dados e associar com o vendedor
           // obj.Department = _context.Department.First();

            //para inserir
            _context.Add(obj);
            //para confirmar 
            _context.SaveChanges();
        }
        public Vendedores FindById(int id)
        {
            return _context.Vendedores.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            //Primeiro pegar  o objeto
            var obj =_context.Vendedores.Find(id);
            //Remover o objeto do DbSte
            _context.Vendedores.Remove(obj);
            //Para confirmar o Entity framework e efetivar no banco de dados
            _context.SaveChanges();
        }
    }
}
