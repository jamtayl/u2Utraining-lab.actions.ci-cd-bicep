﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using U2U.Games.Infra;

namespace U2U.Games.Infra.Migrations
{
    [DbContext(typeof(GamesDb))]
    partial class GamesDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("U2U.Games.Core.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("U2U.Games.Core.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UtcCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime>("UtcModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PublisherId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Qwirkle",
                            PublisherId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rummikub",
                            PublisherId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ticket To Ride",
                            PublisherId = 3
                        });
                });

            modelBuilder.Entity("U2U.Games.Core.Entities.GameImage", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ImageLocation")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("Id");

                    b.ToTable("GameImages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageLocation = "https://u2ublogimages.blob.core.windows.net/cleanarchitecture/GamesStore_Qwirkle.png"
                        },
                        new
                        {
                            Id = 2,
                            ImageLocation = "https://u2ublogimages.blob.core.windows.net/cleanarchitecture/GamesStore_Rummikub.jpg"
                        });
                });

            modelBuilder.Entity("U2U.Games.Core.Entities.GameInBasket", b =>
                {
                    b.Property<int>("ShoppingBasketId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("ShoppingBasketId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GameInBasket");
                });

            modelBuilder.Entity("U2U.Games.Core.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "999 Games"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Goliath"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Days of Wonder"
                        });
                });

            modelBuilder.Entity("U2U.Games.Core.Entities.ShoppingBasket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique()
                        .HasFilter("[CustomerId] IS NOT NULL");

                    b.ToTable("ShoppingBaskets");
                });

            modelBuilder.Entity("U2U.Games.Core.Entities.Customer", b =>
                {
                    b.OwnsOne("U2U.Games.Core.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("CustomerId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("U2U.Games.Core.Entities.Game", b =>
                {
                    b.HasOne("U2U.Games.Core.Entities.Publisher", "Publisher")
                        .WithMany("Games")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("U2U.Currencies.Core.ValueObjects.Money", "Price", b1 =>
                        {
                            b1.Property<int>("GameId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(4,2)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(3)
                                .HasColumnType("nvarchar(3)");

                            b1.HasKey("GameId");

                            b1.ToTable("Games");

                            b1.WithOwner()
                                .HasForeignKey("GameId");

                            b1.HasData(
                                new
                                {
                                    GameId = 1,
                                    Amount = 29.95m,
                                    Currency = "EUR"
                                },
                                new
                                {
                                    GameId = 2,
                                    Amount = 28.95m,
                                    Currency = "USD"
                                },
                                new
                                {
                                    GameId = 3,
                                    Amount = 34.95m,
                                    Currency = "EUR"
                                });
                        });

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("U2U.Games.Core.Entities.GameImage", b =>
                {
                    b.HasOne("U2U.Games.Core.Entities.Game", null)
                        .WithOne("Image")
                        .HasForeignKey("U2U.Games.Core.Entities.GameImage", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("U2U.Games.Core.Entities.GameInBasket", b =>
                {
                    b.HasOne("U2U.Games.Core.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("U2U.Games.Core.Entities.ShoppingBasket", "ShoppingBasket")
                        .WithMany("GamesInBasket")
                        .HasForeignKey("ShoppingBasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("ShoppingBasket");
                });

            modelBuilder.Entity("U2U.Games.Core.Entities.ShoppingBasket", b =>
                {
                    b.HasOne("U2U.Games.Core.Entities.Customer", "Customer")
                        .WithOne("ShoppingBasket")
                        .HasForeignKey("U2U.Games.Core.Entities.ShoppingBasket", "CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("U2U.Games.Core.Entities.Customer", b =>
                {
                    b.Navigation("ShoppingBasket");
                });

            modelBuilder.Entity("U2U.Games.Core.Entities.Game", b =>
                {
                    b.Navigation("Image")
                        .IsRequired();
                });

            modelBuilder.Entity("U2U.Games.Core.Entities.Publisher", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("U2U.Games.Core.Entities.ShoppingBasket", b =>
                {
                    b.Navigation("GamesInBasket");
                });
#pragma warning restore 612, 618
        }
    }
}
