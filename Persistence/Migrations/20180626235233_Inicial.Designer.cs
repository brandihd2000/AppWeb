﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Persistence;
using System;

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180626235233_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Diagnostico", b =>
                {
                    b.Property<int>("idDiagnostico")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("comentario");

                    b.Property<string>("enfermedad");

                    b.Property<string>("especialidad");

                    b.Property<DateTime>("fecha");

                    b.Property<int>("idDoctor");

                    b.Property<int>("idPaciente");

                    b.Property<string>("sintomas");

                    b.Property<int?>("usuarioidUsuario");

                    b.HasKey("idDiagnostico");

                    b.HasIndex("idPaciente");

                    b.HasIndex("usuarioidUsuario");

                    b.ToTable("Diagnostico");
                });

            modelBuilder.Entity("Models.Paciente", b =>
                {
                    b.Property<int>("idPaciente")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("apellido");

                    b.Property<string>("cedula");

                    b.Property<DateTime>("fechaNacimiento");

                    b.Property<string>("grupoSanguineo");

                    b.Property<string>("nombre");

                    b.Property<string>("telefono");

                    b.HasKey("idPaciente");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("Models.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd();

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
                        .HasForeignKey("usuarioidUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
