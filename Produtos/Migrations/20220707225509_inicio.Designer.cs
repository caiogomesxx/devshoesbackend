﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Produtos.Context;

#nullable disable

namespace Produtos.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220707225509_inicio")]
    partial class inicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Produtos.Models.TBCategoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("CategoriaId");

                    b.ToTable("TB_CATEGORIAS");
                });

            modelBuilder.Entity("Produtos.Models.TBImagemProduto", b =>
                {
                    b.Property<int>("ImagemProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("Imagem")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("NomeImagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<long>("TamanhoImagem")
                        .HasColumnType("bigint");

                    b.Property<string>("TipoImagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ImagemProdutoId");

                    b.ToTable("TB_IMAGEM_PRODUTO");
                });

            modelBuilder.Entity("Produtos.Models.TBImagemUsuario", b =>
                {
                    b.Property<int>("ImagemUsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("Imagem")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("NomeImagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TamanhoImagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoImagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ImagemUsuarioID");

                    b.ToTable("TB_IMAGEM_USUARIO");
                });

            modelBuilder.Entity("Produtos.Models.TBProduto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<DateTime>("HoraCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ImagemProdutoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ImagemProdutoId");

                    b.ToTable("TB_PRODUTOS");
                });

            modelBuilder.Entity("Produtos.Models.TBUsuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Admin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ListaImagemUsuarioImagemUsuarioID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UsuarioId");

                    b.HasIndex("ListaImagemUsuarioImagemUsuarioID");

                    b.ToTable("TB_USUARIOS");
                });

            modelBuilder.Entity("Produtos.Models.TBProduto", b =>
                {
                    b.HasOne("Produtos.Models.TBCategoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Produtos.Models.TBImagemProduto", "ImagemProduto")
                        .WithMany("Produtos")
                        .HasForeignKey("ImagemProdutoId");

                    b.Navigation("Categoria");

                    b.Navigation("ImagemProduto");
                });

            modelBuilder.Entity("Produtos.Models.TBUsuario", b =>
                {
                    b.HasOne("Produtos.Models.TBImagemUsuario", "ListaImagemUsuario")
                        .WithMany("Usuarios")
                        .HasForeignKey("ListaImagemUsuarioImagemUsuarioID");

                    b.Navigation("ListaImagemUsuario");
                });

            modelBuilder.Entity("Produtos.Models.TBCategoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Produtos.Models.TBImagemProduto", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Produtos.Models.TBImagemUsuario", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
