using System;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

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
            return _context.Vendedores.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
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

        public void Update(Vendedores obj)
        {
            //Criar uma estrutura if para testar se o objeto existe no banco.
            if(!_context.Vendedores.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado.");
            }
            //pode haver um conflito de captura de exceção de concorrencia
            try
            {
                //atualizrr no banco
                _context.Update(obj);
                _context.SaveChanges();
            }catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
