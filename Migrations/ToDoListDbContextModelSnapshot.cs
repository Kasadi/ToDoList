﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoList.Model;

#nullable disable

namespace ToDoList.Migrations
{
    [DbContext(typeof(ToDoListDbContext))]
    partial class ToDoListDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ItemToDoList", b =>
                {
                    b.Property<int>("ItemsItemId")
                        .HasColumnType("int");

                    b.Property<int>("ToDoListsToDoListId")
                        .HasColumnType("int");

                    b.HasKey("ItemsItemId", "ToDoListsToDoListId");

                    b.HasIndex("ToDoListsToDoListId");

                    b.ToTable("ItemToDoList");
                });

            modelBuilder.Entity("ToDoList.Model.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ItemId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ToDoList.Model.ToDoList", b =>
                {
                    b.Property<int>("ToDoListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ToDoListId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ToDoListId");

                    b.ToTable("ToDoLists");
                });

            modelBuilder.Entity("ItemToDoList", b =>
                {
                    b.HasOne("ToDoList.Model.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoList.Model.ToDoList", null)
                        .WithMany()
                        .HasForeignKey("ToDoListsToDoListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
