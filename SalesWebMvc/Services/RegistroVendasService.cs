using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class RegistroVendasService
    {
        private readonly SalesWebMvcContext _context;

        public RegistroVendasService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroVendas>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.RegistroVendas select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Vendedores)
                .Include(x => x.Vendedores.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
