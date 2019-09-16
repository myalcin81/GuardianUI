﻿// <auto-generated />
using System;
using Guardian.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Guardian.Infrastructure.Migrations
{
    [DbContext(typeof(GuardianDataContext))]
    partial class GuardianDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Account");
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

                    b.Property<bool>("UseHttps");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("Domain")
                        .IsUnique();

                    b.ToTable("Targets");
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
