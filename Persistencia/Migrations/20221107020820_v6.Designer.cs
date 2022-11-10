﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Migrations
{
    [DbContext(typeof(BaseDeDatosSB))]
    [Migration("20221107020820_v6")]
    partial class v6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Dominio.Comentarios.Comentario", b =>
                {
                    b.Property<string>("IdComentario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdComentario");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("Dominio.CV.Cabecera", b =>
                {
                    b.Property<string>("IdCvUsuario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NombreCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobreMi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtitulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("imagen")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("IdCvUsuario");

                    b.ToTable("Cabeceras");
                });

            modelBuilder.Entity("Dominio.CV.Estudios", b =>
                {
                    b.Property<int?>("IdEstudio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdEstudio"), 1L, 1);

                    b.Property<string>("CabeceraIdCvUsuario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Certificaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cursos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("institucion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstudio");

                    b.HasIndex("CabeceraIdCvUsuario");

                    b.ToTable("Estudio");
                });

            modelBuilder.Entity("Dominio.CV.ExpLaboral", b =>
                {
                    b.Property<string>("IdExpLaboral")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("FechaEgreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdCvUsuario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NombreEmpresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Puesto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("texto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdExpLaboral");

                    b.HasIndex("IdCvUsuario");

                    b.ToTable("Exps");
                });

            modelBuilder.Entity("Dominio.CV.Idiomas", b =>
                {
                    b.Property<int>("IdIdioma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdIdioma"), 1L, 1);

                    b.Property<string>("CabeceraIdCvUsuario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("lenguas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdIdioma");

                    b.HasIndex("CabeceraIdCvUsuario");

                    b.ToTable("Idioma");
                });

            modelBuilder.Entity("Dominio.CV.ImageSkills", b =>
                {
                    b.Property<int>("imageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("imageId"), 1L, 1);

                    b.Property<string>("Base64Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdSkill")
                        .HasColumnType("int");

                    b.Property<byte[]>("imageContent")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("imageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("imageId");

                    b.HasIndex("IdSkill");

                    b.ToTable("ImageSkill");
                });

            modelBuilder.Entity("Dominio.CV.Skills", b =>
                {
                    b.Property<int>("IdSkill")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSkill"), 1L, 1);

                    b.Property<string>("CabeceraIdCvUsuario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NameSkill")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSkill");

                    b.HasIndex("CabeceraIdCvUsuario");

                    b.ToTable("Habilidades");
                });

            modelBuilder.Entity("Dominio.Usuarios.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NombreCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("imagen")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Dominio.CV.Estudios", b =>
                {
                    b.HasOne("Dominio.CV.Cabecera", null)
                        .WithMany("Estudios")
                        .HasForeignKey("CabeceraIdCvUsuario");
                });

            modelBuilder.Entity("Dominio.CV.ExpLaboral", b =>
                {
                    b.HasOne("Dominio.CV.Cabecera", null)
                        .WithMany("ExpLaborales")
                        .HasForeignKey("IdCvUsuario");
                });

            modelBuilder.Entity("Dominio.CV.Idiomas", b =>
                {
                    b.HasOne("Dominio.CV.Cabecera", null)
                        .WithMany("Idiomas")
                        .HasForeignKey("CabeceraIdCvUsuario");
                });

            modelBuilder.Entity("Dominio.CV.ImageSkills", b =>
                {
                    b.HasOne("Dominio.CV.Skills", null)
                        .WithMany("ImageSkills")
                        .HasForeignKey("IdSkill")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.CV.Skills", b =>
                {
                    b.HasOne("Dominio.CV.Cabecera", null)
                        .WithMany("skills")
                        .HasForeignKey("CabeceraIdCvUsuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Dominio.Usuarios.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Dominio.Usuarios.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Usuarios.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Dominio.Usuarios.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.CV.Cabecera", b =>
                {
                    b.Navigation("Estudios");

                    b.Navigation("ExpLaborales");

                    b.Navigation("Idiomas");

                    b.Navigation("skills");
                });

            modelBuilder.Entity("Dominio.CV.Skills", b =>
                {
                    b.Navigation("ImageSkills");
                });
#pragma warning restore 612, 618
        }
    }
}