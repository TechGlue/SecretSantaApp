// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecretSanta.Data;

namespace SecretSanta.Data.Migrations
{
    [DbContext(typeof(SecretSantaContext))]
    [Migration("20220106003107_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GroupsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("SecretSanta.Data.Assignment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GiverId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ReceiverId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("GiverId");

                    b.HasIndex("GroupId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("SecretSanta.Data.Gift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("SecretSanta.Data.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = "",
                            Location = "",
                            Name = "Luis's pizza"
                        },
                        new
                        {
                            Id = 2,
                            Date = "",
                            Location = "",
                            Name = "Luis's Diner"
                        });
                });

            modelBuilder.Entity("SecretSanta.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "123@gmail.com",
                            FirstName = "Luis",
                            LastName = "Garcia"
                        },
                        new
                        {
                            Id = 2,
                            Email = "123@gmail.com",
                            FirstName = "Jeff",
                            LastName = "Kapplan"
                        },
                        new
                        {
                            Id = 3,
                            Email = "123@gmail.com",
                            FirstName = "Terry",
                            LastName = "Crews"
                        });
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.HasOne("SecretSanta.Data.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecretSanta.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SecretSanta.Data.Assignment", b =>
                {
                    b.HasOne("SecretSanta.Data.User", "Giver")
                        .WithMany()
                        .HasForeignKey("GiverId");

                    b.HasOne("SecretSanta.Data.Group", "Group")
                        .WithMany("Assignments")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecretSanta.Data.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId");

                    b.Navigation("Giver");

                    b.Navigation("Group");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("SecretSanta.Data.Gift", b =>
                {
                    b.HasOne("SecretSanta.Data.User", "Receiver")
                        .WithMany("Gifts")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("SecretSanta.Data.Group", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("SecretSanta.Data.User", b =>
                {
                    b.Navigation("Gifts");
                });
#pragma warning restore 612, 618
        }
    }
}
