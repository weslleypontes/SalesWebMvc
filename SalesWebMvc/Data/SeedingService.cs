using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using Microsoft.EntityFrameworkCore;
namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void SeedAsync()
        {
            bool departamento =  _context.Department.Any();
            bool vendecores =  _context.Vendedores.Any();
            bool registroVendas = _context.RegistroVendas.Any();
            if (departamento ||
                vendecores ||
                registroVendas)
            {
                return; // DB has been seeded
            }

            Department d1 = new Department(new int(), "Computers");

            Department d2 = new Department(new int(), "Electronics");

            Department d3 = new Department(new int(), "Fashion");

            Department d4 = new Department(new int(), "Books");

            Vendedores s1 = new Vendedores(new int(), "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Vendedores s2 = new Vendedores(new int(), "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Vendedores s3 = new Vendedores(new int(), "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Vendedores s4 = new Vendedores(new int(), "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Vendedores s5 = new Vendedores(new int(), "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Vendedores s6 = new Vendedores(new int(), "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            RegistroVendas r1 = new RegistroVendas(new int(), new DateTime(2018, 09, 25), 11000.0, StatusVendedor.Billed, s1);
            RegistroVendas r2 = new RegistroVendas(new int(), new DateTime(2018, 09, 4), 7000.0, StatusVendedor.Billed, s5);
            RegistroVendas r3 = new RegistroVendas(new int(), new DateTime(2018, 09, 13), 4000.0, StatusVendedor.Canceled, s4);
            RegistroVendas r4 = new RegistroVendas(new int(), new DateTime(2018, 09, 1), 8000.0, StatusVendedor.Billed, s1);
            RegistroVendas r5 = new RegistroVendas(new int(), new DateTime(2018, 09, 21), 3000.0, StatusVendedor.Billed, s3);
            RegistroVendas r6 = new RegistroVendas(new int(), new DateTime(2018, 09, 15), 2000.0, StatusVendedor.Billed, s1);
            RegistroVendas r7 = new RegistroVendas(new int(), new DateTime(2018, 09, 28), 13000.0, StatusVendedor.Billed, s2);
            RegistroVendas r8 = new RegistroVendas(new int(), new DateTime(2018, 09, 11), 4000.0, StatusVendedor.Billed, s4);
            RegistroVendas r9 = new RegistroVendas(new int(), new DateTime(2018, 09, 14), 11000.0, StatusVendedor.Pending, s6);
            RegistroVendas r10 = new RegistroVendas(new int(), new DateTime(2018, 09, 7), 9000.0, StatusVendedor.Billed, s6);
            RegistroVendas r11 = new RegistroVendas(new int(), new DateTime(2018, 09, 13), 6000.0, StatusVendedor.Billed, s2);
            RegistroVendas r12 = new RegistroVendas(new int(), new DateTime(2018, 09, 25), 7000.0, StatusVendedor.Pending, s3);
            RegistroVendas r13 = new RegistroVendas(new int(), new DateTime(2018, 09, 29), 10000.0, StatusVendedor.Billed, s4);
            RegistroVendas r14 = new RegistroVendas(new int(), new DateTime(2018, 09, 4), 3000.0, StatusVendedor.Billed, s5);
            RegistroVendas r15 = new RegistroVendas(new int(), new DateTime(2018, 09, 12), 4000.0, StatusVendedor.Billed, s1);
            RegistroVendas r16 = new RegistroVendas(new int(), new DateTime(2018, 10, 5), 2000.0, StatusVendedor.Billed, s4);
            RegistroVendas r17 = new RegistroVendas(new int(), new DateTime(2018, 10, 1), 12000.0, StatusVendedor.Billed, s1);
            RegistroVendas r18 = new RegistroVendas(new int(), new DateTime(2018, 10, 24), 6000.0, StatusVendedor.Billed, s3);
            RegistroVendas r19 = new RegistroVendas(new int(), new DateTime(2018, 10, 22), 8000.0, StatusVendedor.Billed, s5);
            RegistroVendas r20 = new RegistroVendas(new int(), new DateTime(2018, 10, 15), 8000.0, StatusVendedor.Billed, s6);
            RegistroVendas r21 = new RegistroVendas(new int(), new DateTime(2018, 10, 17), 9000.0, StatusVendedor.Billed, s2);
            RegistroVendas r22 = new RegistroVendas(new int(), new DateTime(2018, 10, 24), 4000.0, StatusVendedor.Billed, s4);
            RegistroVendas r23 = new RegistroVendas(new int(), new DateTime(2018, 10, 19), 11000.0, StatusVendedor.Canceled, s2);
            RegistroVendas r24 = new RegistroVendas(new int(), new DateTime(2018, 10, 12), 8000.0, StatusVendedor.Billed, s5);
            RegistroVendas r25 = new RegistroVendas(new int(), new DateTime(2018, 10, 31), 7000.0, StatusVendedor.Billed, s3);
            RegistroVendas r26 = new RegistroVendas(new int(), new DateTime(2018, 10, 6), 5000.0, StatusVendedor.Billed, s4);
            RegistroVendas r27 = new RegistroVendas(new int(), new DateTime(2018, 10, 13), 9000.0, StatusVendedor.Pending, s1);
            RegistroVendas r28 = new RegistroVendas(new int(), new DateTime(2018, 10, 7), 4000.0, StatusVendedor.Billed, s3);
            RegistroVendas r29 = new RegistroVendas(new int(), new DateTime(2018, 10, 23), 12000.0, StatusVendedor.Billed, s5);
            RegistroVendas r30 = new RegistroVendas(new int(), new DateTime(2018, 10, 12), 5000.0, StatusVendedor.Billed, s2);

             _context.Department.AddRange(d1, d2, d3, d4);

            _context.Vendedores.AddRange(s1, s2, s3, s4, s5, s6);

            _context.RegistroVendas.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();
        }
    }
}
