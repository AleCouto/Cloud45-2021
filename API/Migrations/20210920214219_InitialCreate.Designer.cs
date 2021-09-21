﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(DataBaseStore))]
    [Migration("20210920214219_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("BusinessLogic.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Plantas"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Flores"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Produtos para cultivo"
                        });
                });

            modelBuilder.Entity("BusinessLogic.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            Price = 0m,
                            Quantity = 0,
                            UserId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            Price = 0m,
                            Quantity = 0,
                            UserId = 2
                        },
                        new
                        {
                            OrderId = 3,
                            Price = 0m,
                            Quantity = 0,
                            UserId = 3
                        },
                        new
                        {
                            OrderId = 4,
                            Price = 0m,
                            Quantity = 0,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("BusinessLogic.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<string>("ImgFotoProduct")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Amount = 1,
                            CategoryId = 1,
                            Description = "De crescimento rápido e folha persistente, esta planta trepadeira tem o nome Brasil devido às tonalidades verde e amarela das suas folhas.",
                            ImgFotoProduct = "/images/PhilodendronBrasil.png",
                            Name = "Philodendron Brasil",
                            Price = 5m
                        },
                        new
                        {
                            ProductId = 2,
                            Amount = 1,
                            CategoryId = 1,
                            Description = "Com folhas grandes, verdes e em forma de coração, a Monstera deliciosa ou Costela de Adão ganha aberturas nas folhas à medida que estas amadurecem.",
                            ImgFotoProduct = "/images/MonsteraDeliciosa.png",
                            Name = "Monstera Deliciosa",
                            Price = 14m
                        },
                        new
                        {
                            ProductId = 3,
                            Amount = 1,
                            CategoryId = 1,
                            Description = "Folhas grandes, redondas, com tonalidades verdes e listas verdes claras.",
                            ImgFotoProduct = "/images/Calathea Orbifolia.png",
                            Name = "Calathea Orbifolia",
                            Price = 21m
                        },
                        new
                        {
                            ProductId = 4,
                            Amount = 1,
                            CategoryId = 2,
                            Description = "Florescem duas ou três vezes ao ano, precisam de muita luz, mas não luz directa, por isso, é aconselhável usar a luz do final do dia, para que floresçam e sigam radiantes.",
                            ImgFotoProduct = "/images/Orquidea.png",
                            Name = "Orquídea",
                            Price = 46m
                        },
                        new
                        {
                            ProductId = 5,
                            Amount = 1,
                            CategoryId = 2,
                            Description = "O resultado: fusão perfeita entre pureza, jovialidade e inocência. A combinação ideal, para presentear sem nenhuma razão.",
                            ImgFotoProduct = "/images/MargaridasBrancas.png",
                            Name = "Margaridas Brancas",
                            Price = 37m
                        },
                        new
                        {
                            ProductId = 6,
                            Amount = 1,
                            CategoryId = 2,
                            Description = "É uma planta de folhas grossas em forma de coração, vistosas e originais flores, que podem ser cor-de-rosa, brancas o amarelas... Mesmo que sem dúvida a cor estrela pelo seu contraste é o vermelho.",
                            ImgFotoProduct = "/images/Anthurium.png",
                            Name = "Anthurium",
                            Price = 45m
                        },
                        new
                        {
                            ProductId = 7,
                            Amount = 1,
                            CategoryId = 3,
                            Description = "Vaso de cerâmica vitória de qualidade superior indicado para plantas de interior.",
                            ImgFotoProduct = "/images/images/vasovitoria.png",
                            Name = "Vaso Vitória",
                            Price = 6m
                        },
                        new
                        {
                            ProductId = 8,
                            Amount = 1,
                            CategoryId = 3,
                            Description = "Adubo biológico universal líquido, ideal para plantas de interior e exterior.",
                            ImgFotoProduct = "/images/AduboBiologico.png",
                            Name = "Adubo Biológico Universal Líquido 780ml",
                            Price = 7m
                        },
                        new
                        {
                            ProductId = 9,
                            Amount = 1,
                            CategoryId = 3,
                            Description = "Substrato universal biológico Siro® Platina feito com matérias primas 100% sustentáveis e indicado para plantação ou transplante de plantas decorativas ou comestíveis.",
                            ImgFotoProduct = "/images/SubstratoUniversal.png",
                            Name = "Substrato Universal Biológico 20l",
                            Price = 6m
                        });
                });

            modelBuilder.Entity("BusinessLogic.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AccessLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FiscalNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Indentification")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostalCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            AccessLevel = true,
                            Address = "Rua Vitimas da Guerra 30",
                            Email = "aecmar@hotmail.com",
                            FiscalNumber = 0,
                            Name = "Alexandre Couto",
                            PhoneNumber = 222222222,
                            PostalCode = 2825420
                        },
                        new
                        {
                            UserId = 2,
                            AccessLevel = true,
                            Address = "Rua Lisboa 40",
                            Email = "jg@hotmail.com",
                            FiscalNumber = 0,
                            Name = "João Golçalves",
                            PhoneNumber = 333333333,
                            PostalCode = 1234567
                        },
                        new
                        {
                            UserId = 3,
                            AccessLevel = true,
                            Address = "Rua Almirante reis 3",
                            Email = "apjose@hotmail.com",
                            FiscalNumber = 0,
                            Name = "Pedro Jose",
                            PhoneNumber = 444444444,
                            PostalCode = 7654321
                        });
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("BusinessLogic.Order", b =>
                {
                    b.HasOne("BusinessLogic.User", "User")
                        .WithMany("Order")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BusinessLogic.Product", b =>
                {
                    b.HasOne("BusinessLogic.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("BusinessLogic.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessLogic.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BusinessLogic.Category", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("BusinessLogic.User", b =>
                {
                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
