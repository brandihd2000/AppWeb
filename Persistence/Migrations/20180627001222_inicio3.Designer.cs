﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180627001222_inicio3")]
    partial class inicio3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Diagnostico", b =>
                {
                    b.Property<int>("idDiagnostico")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("comentario");

                    b.Property<string>("enfermedad");

                    b.Property<string>("especialidad");

                    b.Property<DateTime>("fecha");

                    b.Property<int>("idPaciente");

                    b.Property<int>("idUsuario");

                    b.Property<string>("sintomas");

                    b.HasKey("idDiagnostico");

                    b.HasIndex("idPaciente");

                    b.HasIndex("idUsuario");

                    b.ToTable("Diagnostico");
                });

            modelBuilder.Entity("Models.Observaciones", b =>
                {
                    b.Property<int>("idObservaciones")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("alergias");

                    b.Property<string>("discapacidad");

                    b.Property<string>("enfermedades");

                    b.Property<int>("idPaciente");

                    b.Property<string>("medicamentos");

                    b.HasKey("idObservaciones");

                    b.HasIndex("idPaciente");

                    b.ToTable("Observaciones");
                });

            modelBuilder.Entity("Models.Paciente", b =>
                {
                    b.Property<int>("idPaciente")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido");

                    b.Property<string>("cedula");

                    b.Property<DateTime>("fechaNacimiento");

                    b.Property<string>("grupoSanguineo");

                    b.Property<string>("nombre");

                    b.Property<string>("telefono");

                    b.HasKey("idPaciente");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("Models.Tratamiento", b =>
                {
                    b.Property<int>("idTratamiento")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("comentario");

                    b.Property<DateTime>("fechaFin");

                    b.Property<DateTime>("fechaInicio");

                    b.Property<int>("idDiagnostico");

                    b.HasKey("idTratamiento");

                    b.HasIndex("idDiagnostico");

                    b.ToTable("Tratamiento");
                });

            modelBuilder.Entity("Models.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido");

                    b.Property<string>("contraseña");

                    b.Property<string>("email");

                    b.Property<string>("especialidad");

                    b.Property<string>("nombre");

                    b.Property<string>("tipo");

                    b.HasKey("idUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Models.Diagnostico", b =>
                {
                    b.HasOne("Models.Paciente", "paciente")
                        .WithMany()
                        .HasForeignKey("idPaciente")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("idUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Observaciones", b =>
                {
                    b.HasOne("Models.Paciente", "paciente")
                        .WithMany()
                        .HasForeignKey("idPaciente")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Tratamiento", b =>
                {
                    b.HasOne("Models.Diagnostico", "diagnostico")
                        .WithMany()
                        .HasForeignKey("idDiagnostico")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
