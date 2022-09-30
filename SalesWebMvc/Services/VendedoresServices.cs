using System;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class VendedoresServices
    {

        private readonly SalesWebMvcContext _context;

        public VendedoresServices(SalesWebMvcContext context)
        {
            _context = context;
        }
         
        public async Task<List<Vendedores>> FindAllAsync()
        {
            return await _context.Vendedores.ToListAsync();
        }
        //metodo para inseir um novo cadastro
        public async Task InsertAsync(Vendedores obj)
        {
            //pegar o primeiro elemento do banco de dados e associar com o vendedor
           // obj.Department = _context.Department.First();

            //para inserir na menoria
            _context.Add(obj);
            //para confirmar no banco
            await _context.SaveChangesAsync();
        }
        public async Task<Vendedores> FindByIdAsync(int id)
        {
            return await _context.Vendedores.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            //Primeiro pegar  o objeto
            var obj = await _context.Vendedores.FindAsync(id);
            //Remover o objeto do DbSte
            _context.Vendedores.Remove(obj);
            //Para confirmar o Entity framework e efetivar no banco de dados
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vendedores obj)
        {
            bool hasAny = await _context.Vendedores.AnyAsync(x => x.Id == obj.Id);
            //Criar uma estrutura if para testar se o objeto existe no banco.
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }
            //pode haver um conflito de captura de exceção de concorrencia
            try
            {
                //atualizrr no banco
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
