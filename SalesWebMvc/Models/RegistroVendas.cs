using System;
using SalesWebMvc.Models.Enums;
namespace SalesWebMvc.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public StatusVendedor Status { get; set; }
        public Vendedores Vendedores { get; set; }

        public RegistroVendas()
        {
        }

        public RegistroVendas(int id, DateTime date, double amount, StatusVendedor status, Vendedores vendedores)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Vendedores = vendedores;
        }
    }
}
