﻿// <auto-generated />
using GlobalSolution.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace GlobalSolution.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GlobalSolution.Models.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EstacionamentoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("EstacionamentoId");

                    b.ToTable("GS_CARRO");
                });

            modelBuilder.Entity("GlobalSolution.Models.Estacionamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("GS_ESTACIONAMENTO_NET");
                });

            modelBuilder.Entity("GlobalSolution.Models.Carro", b =>
                {
                    b.HasOne("GlobalSolution.Models.Estacionamento", "Estacionamento")
                        .WithMany()
                        .HasForeignKey("EstacionamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estacionamento");
                });
#pragma warning restore 612, 618
        }
    }
}