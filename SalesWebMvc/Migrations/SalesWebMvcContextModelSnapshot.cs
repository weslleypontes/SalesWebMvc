﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesWebMvc.Data;

namespace SalesWebMvc.Migrations
{
    [DbContext(typeof(SalesWebMvcContext))]
    partial class SalesWebMvcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SalesWebMvc.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("SalesWebMvc.Models.RegistroVendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Status");

                    b.Property<int?>("VendedoresId");

                    b.HasKey("Id");

                    b.HasIndex("VendedoresId");

                    b.ToTable("RegistroVendas");
                });

            modelBuilder.Entity("SalesWebMvc.Models.Vendedores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento");

                    b.Property<int?>("DepartmentId");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<double>("SalarioBase");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("SalesWebMvc.Models.RegistroVendas", b =>
                {
                    b.HasOne("SalesWebMvc.Models.Vendedores", "Vendedores")
                        .WithMany("Vendas")
                        .HasForeignKey("VendedoresId");
                });

            modelBuilder.Entity("SalesWebMvc.Models.Vendedores", b =>
                {
                    b.HasOne("SalesWebMvc.Models.Department", "Department")
                        .WithMany("Vendedores")
                        .HasForeignKey("DepartmentId");
                });
#pragma warning restore 612, 618
        }
    }
}
