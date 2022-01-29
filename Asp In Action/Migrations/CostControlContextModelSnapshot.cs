﻿// <auto-generated />
using System;
using Asp_In_Action.Services.CostControl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Asp_In_Action.Migrations
{
    [DbContext(typeof(CostControlContext))]
    partial class CostControlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Asp_In_Action.Services.CostControl.Entity.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CostControlAccounts");
                });

            modelBuilder.Entity("Asp_In_Action.Services.CostControl.Entity.Balance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("CostControlBalances");
                });

            modelBuilder.Entity("Asp_In_Action.Services.CostControl.Entity.Expense", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("CostControlExpenses");
                });

            modelBuilder.Entity("Asp_In_Action.Services.CostControl.Entity.Income", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("CostControlIncomes");
                });

            modelBuilder.Entity("Asp_In_Action.Services.CostControl.Entity.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AccountFromId")
                        .HasColumnType("bigint");

                    b.Property<long?>("AccountToId")
                        .HasColumnType("bigint");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ExpenseId")
                        .HasColumnType("bigint");

                    b.Property<long?>("IncomeId")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AccountFromId");

                    b.HasIndex("AccountToId");

                    b.HasIndex("ExpenseId");

                    b.HasIndex("IncomeId");

                    b.HasIndex("UserId");

                    b.ToTable("CostControlTransactions");
                });

            modelBuilder.Entity("Asp_In_Action.Services.CostControl.Entity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CostControlUsers");
                });

            modelBuilder.Entity("Asp_In_Action.Services.CostControl.Entity.Account", b =>
                {
                    b.HasOne("Asp_In_Action.Services.CostControl.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Asp_In_Action.Services.CostControl.Entity.Balance", b =>
                {
                    b.HasOne("Asp_In_Action.Services.CostControl.Entity.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Asp_In_Action.Services.CostControl.Entity.Expense", b =>
                {
                    b.HasOne("Asp_In_Action.Services.CostControl.Entity.Expense", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("Asp_In_Action.Services.CostControl.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Parent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Asp_In_Action.Services.CostControl.Entity.Income", b =>
                {
                    b.HasOne("Asp_In_Action.Services.CostControl.Entity.Income", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("Asp_In_Action.Services.CostControl.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Parent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Asp_In_Action.Services.CostControl.Entity.Transaction", b =>
                {
                    b.HasOne("Asp_In_Action.Services.CostControl.Entity.Account", "AccountFrom")
                        .WithMany()
                        .HasForeignKey("AccountFromId");

                    b.HasOne("Asp_In_Action.Services.CostControl.Entity.Account", "AccountTo")
                        .WithMany()
                        .HasForeignKey("AccountToId");

                    b.HasOne("Asp_In_Action.Services.CostControl.Entity.Expense", "Expense")
                        .WithMany()
                        .HasForeignKey("ExpenseId");

                    b.HasOne("Asp_In_Action.Services.CostControl.Entity.Income", "Income")
                        .WithMany()
                        .HasForeignKey("IncomeId");

                    b.HasOne("Asp_In_Action.Services.CostControl.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("AccountFrom");

                    b.Navigation("AccountTo");

                    b.Navigation("Expense");

                    b.Navigation("Income");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
