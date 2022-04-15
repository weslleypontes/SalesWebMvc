using System.Collections.Generic;
using System;
using System.Linq;
namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Vendedores> Vendedores { get; set; } = new List<Vendedores>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddVendedor(Vendedores vendedores)
        {
            Vendedores.Add(vendedores);
        }

        public double TotalVendedor(DateTime inicio, DateTime fim)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalVendas(inicio, fim));
        }
    }
}
