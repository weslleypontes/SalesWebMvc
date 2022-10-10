using System;
using System.ComponentModel.DataAnnotations;
using SalesWebMvc.Models.Enums;
namespace SalesWebMvc.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString ="{0:F2}")]
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
