﻿// <auto-generated />
using System;
using Guardian.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Guardian.Infrastructure.Migrations
{
    [DbContext(typeof(GuardianDataContext))]
    [Migration("20191005105959_WafActionAdded")]
    partial class WafActionAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Guardian.Infrastructure.Entity.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("Email")
                        .HasMaxLength(200);

                    b.Property<string>("FullName")
                        .HasMaxLength(50);

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.Property<string>("Salt");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.FirewallRule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<int>("Action");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("Expression");

                    b.Property<bool>("IsActive");

                    b.Property<int>("RuleFor");

                    b.Property<Guid>("TargetId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("TargetId");

                    b.ToTable("FirewallRules");
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.HTTPLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<long>("HttpElapsed");

                    b.Property<long>("RequestSize");

                    b.Property<string>("RequestUri");

                    b.Property<long>("ResponseSize");

                    b.Property<long>("RuleCheckElapsed");

                    b.Property<int>("StatusCode");

                    b.Property<Guid>("TargetId");

                    b.HasKey("Id");

                    b.HasIndex("TargetId");

                    b.ToTable("HTTPLogs");
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.RuleLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<int>("ExecutionMillisecond");

                    b.Property<Guid?>("FirewallRuleId");

                    b.Property<bool>("IsHitted");

                    b.Property<int>("LogType");

                    b.Property<string>("RequestUri");

                    b.Property<int>("RuleFor");

                    b.Property<Guid>("TargetId");

                    b.Property<int>("WafAction");

                    b.HasKey("Id");

                    b.HasIndex("FirewallRuleId");

                    b.HasIndex("TargetId");

                    b.ToTable("RuleLogs");
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.Target", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<string>("CertCrt");

                    b.Property<string>("CertKey");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("Domain")
                        .HasMaxLength(250);

                    b.Property<string>("OriginIpAddress")
                        .HasMaxLength(250);

                    b.Property<int>("Proto");

                    b.Property<int>("State");

                    b.Property<bool>("UseHttps");

                    b.Property<bool>("WAFEnabled");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("Domain", "State");

                    b.ToTable("Targets");
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.FirewallRule", b =>
                {
                    b.HasOne("Guardian.Infrastructure.Entity.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Guardian.Infrastructure.Entity.Target", "Target")
                        .WithMany("FirewallRules")
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.HTTPLog", b =>
                {
                    b.HasOne("Guardian.Infrastructure.Entity.Target", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.RuleLog", b =>
                {
                    b.HasOne("Guardian.Infrastructure.Entity.FirewallRule", "FirewallRule")
                        .WithMany("RuleLogs")
                        .HasForeignKey("FirewallRuleId");

                    b.HasOne("Guardian.Infrastructure.Entity.Target", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Guardian.Infrastructure.Entity.Target", b =>
                {
                    b.HasOne("Guardian.Infrastructure.Entity.Account", "Account")
                        .WithMany("Targets")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
