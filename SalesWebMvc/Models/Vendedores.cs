using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace SalesWebMvc.Models
{
    public class Vendedores
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Salario Base")]
        [DisplayFormat(DataFormatString ="{0:f2}")]
        public double SalarioBase { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<RegistroVendas> Vendas { get; set; } = new List<RegistroVendas>();

        public Vendedores()
        {
        }

        public Vendedores(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Department department)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Department = department;
        }

        public void AddVenda(RegistroVendas rv)
        {
            Vendas.Add(rv);
        }

        public void RemoverVenda(RegistroVendas rv)
        {
            Vendas.Remove(rv);
        }

        public double TotalVendas(DateTime inicio, DateTime fim)
        {
            return Vendas.Where(rv => rv.Date >= inicio && rv.Date <= fim).Sum(rv => rv.Amount);
        }
    }
}
