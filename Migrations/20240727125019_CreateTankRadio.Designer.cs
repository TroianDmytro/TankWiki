﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TankWiki.Models;

#nullable disable

namespace TankWiki.Migrations
{
    [DbContext(typeof(MySqlDBContext))]
    [Migration("20240727125019_CreateTankRadio")]
    partial class CreateTankRadio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.6.24327.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TankWiki.Models.ModelOneToMany.TankEngine", b =>
                {
                    b.Property<int>("EngineId")
                        .HasColumnType("int");

                    b.Property<int>("TankId")
                        .HasColumnType("int");

                    b.HasKey("EngineId", "TankId");

                    b.HasIndex("TankId");

                    b.ToTable("TankEngines");
                });

            modelBuilder.Entity("TankWiki.Models.ModelOneToMany.TankRadio", b =>
                {
                    b.Property<int>("RadioId")
                        .HasColumnType("int");

                    b.Property<int>("TankId")
                        .HasColumnType("int");

                    b.HasKey("RadioId", "TankId");

                    b.HasIndex("TankId");

                    b.ToTable("TankRadios");
                });

            modelBuilder.Entity("TankWiki.Models.ModelOneToMany.TankSuspension", b =>
                {
                    b.Property<int>("SuspensionId")
                        .HasColumnType("int");

                    b.Property<int>("TankId")
                        .HasColumnType("int");

                    b.HasKey("SuspensionId", "TankId");

                    b.HasIndex("TankId");

                    b.ToTable("TankSuspensions");
                });

            modelBuilder.Entity("TankWiki.Models.ModelOneToMany.TankTurret", b =>
                {
                    b.Property<int>("TurretId")
                        .HasColumnType("int");

                    b.Property<int>("TankId")
                        .HasColumnType("int");

                    b.HasKey("TurretId", "TankId");

                    b.HasIndex("TankId");

                    b.ToTable("TankTurrets");
                });

            modelBuilder.Entity("TankWiki.Models.ModelOneToMany.TurretGun", b =>
                {
                    b.Property<int>("TurretId")
                        .HasColumnType("int");

                    b.Property<int>("GunId")
                        .HasColumnType("int");

                    b.HasKey("TurretId", "GunId");

                    b.HasIndex("GunId");

                    b.ToTable("TurretGuns");
                });

            modelBuilder.Entity("TankWiki.Models.ModelTank.Armor", b =>
                {
                    b.Property<int>("ArmorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArmorId"));

                    b.Property<int>("HullFront")
                        .HasColumnType("int");

                    b.Property<int>("HullRear")
                        .HasColumnType("int");

                    b.Property<int>("HullSide")
                        .HasColumnType("int");

                    b.HasKey("ArmorId");

                    b.ToTable("Armors");
                });

            modelBuilder.Entity("TankWiki.Models.ModelTank.Engine", b =>
                {
                    b.Property<int>("EngineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EngineId"));

                    b.Property<double>("FireChance")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<int>("Tier")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("EngineId");

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("TankWiki.Models.ModelTank.Gun", b =>
                {
                    b.Property<int>("GunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GunId"));

                    b.Property<double>("Accuracy")
                        .HasColumnType("float");

                    b.Property<double>("AimTime")
                        .HasColumnType("float");

                    b.Property<int>("Ammunition")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Penetration")
                        .HasColumnType("int");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<double>("RateOfFire")
                        .HasColumnType("float");

                    b.Property<int>("Tier")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("GunId");

                    b.ToTable("Guns");
                });

            modelBuilder.Entity("TankWiki.Models.ModelTank.Radio", b =>
                {
                    b.Property<int>("RadioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RadioId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<int>("SignalRange")
                        .HasColumnType("int");

                    b.Property<int>("Tier")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("RadioId");

                    b.ToTable("Radios");
                });

            modelBuilder.Entity("TankWiki.Models.ModelTank.Suspension", b =>
                {
                    b.Property<int>("SuspensionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SuspensionId"));

                    b.Property<int>("LoadLimit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<int>("Tier")
                        .HasColumnType("int");

                    b.Property<int>("TraverseSpeed")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("SuspensionId");

                    b.ToTable("Suspensions");
                });

            modelBuilder.Entity("TankWiki.Models.ModelTank.Tank", b =>
                {
                    b.Property<int>("TankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TankId"));

                    b.Property<int>("ArmorId")
                        .HasColumnType("int");

                    b.Property<string>("Crew")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("Tier")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("TankId");

                    b.HasIndex("ArmorId");

                    b.HasIndex("TypeId");

                    b.ToTable("Tanks");
                });

            modelBuilder.Entity("TankWiki.Models.ModelTank.TypeMachine", b =>
                {
                    b.Property<int>("TankTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TankTypeId"));

                    b.Property<string>("TypeMachine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TankTypeId");

                    b.ToTable("TankTypes");
                });

            modelBuilder.Entity("TankWiki.Models.ModelTank.Turret", b =>
                {
                    b.Property<int>("TurretId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TurretId"));

                    b.Property<int>("Overview")
                        .HasColumnType("int");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<int>("Tier")
                        .HasColumnType("int");

                    b.Property<double>("Turn")
                        .HasColumnType("float");

                    b.Property<int>("TurretFront")
                        .HasColumnType("int");

                    b.Property<string>("TurretName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TurretRear")
                        .HasColumnType("int");

                    b.Property<int>("TurretSide")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("TurretId");

                    b.ToTable("Turrets");
                });

            modelBuilder.Entity("TankWiki.Models.Nations", b =>
                {
                    b.Property<int>("NationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NationId"));

                    b.Property<string>("NationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NationId");

                    b.ToTable("Nations");
                });

            modelBuilder.Entity("TankWiki.Models.ModelOneToMany.TankEngine", b =>
                {
                    b.HasOne("TankWiki.Models.ModelTank.Engine", "Engine")
                        .WithMany("TankEngines")
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TankWiki.Models.ModelTank.Tank", "Tank")
                        .WithMany("TankEngines")
                        .HasForeignKey("TankId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Engine");

                    b.Navigation("Tank");
                });

            modelBuilder.Entity("TankWiki.Models.ModelOneToMany.TankRadio", b =>
                {
                    b.HasOne("TankWiki.Models.ModelTank.Radio", "Radio")
                        .WithMany("TankRadios")
                        .HasForeignKey("RadioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TankWiki.Models.ModelTank.Tank", "Tank")
                        .WithMany("TankRadios")
                        .HasForeignKey("TankId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Radio");

                    b.Navigation("Tank");
                });

            modelBuilder.Entity("TankWiki.Models.ModelOneToMany.TankSuspension", b =>
                {
                    b.HasOne("TankWiki.Models.ModelTank.Suspension", "Suspension")
                        .WithMany("TankSuspensions")
                        .HasForeignKey("SuspensionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TankWiki.Models.ModelTank.Tank", "Tank")
                        .WithMany("TankSuspensions")
                        .HasForeignKey("TankId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Suspension");

                    b.Navigation("Tank");
                });

            modelBuilder.Entity("TankWiki.Models.ModelOneToMany.TankTurret", b =>
                {
                    b.HasOne("TankWiki.Models.ModelTank.Tank", "Tank")
                        .WithMany("TankTurrets")
                        .HasForeignKey("TankId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TankWiki.Models.ModelTank.Turret", "Turret")
                        .WithMany("TankTurrets")
                        .HasForeignKey("TurretId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tank");

                    b.Navigation("Turret");
                });

            modelBuilder.Entity("TankWiki.Models.ModelOneToMany.TurretGun", b =>
                {
                    b.HasOne("TankWiki.Models.ModelTank.Gun", "Gun")
                        .WithMany("TurretGuns")
                        .HasForeignKey("GunId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TankWiki.Models.ModelTank.Turret", "Turret")
                        .WithMany("TurretGuns")
                        .HasForeignKey("TurretId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Gun");

                    b.Navigation("Turret");
                });

            modelBuilder.Entity("TankWiki.Models.ModelTank.Tank", b =>
                {
                    b.HasOne("TankWiki.Models.ModelTank.Armor", "Armor")
                        .WithMany()
                        .HasForeignKey("ArmorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TankWiki.Models.ModelTank.TypeMachine", "TypeMachine")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Armor");

                    b.Navigation("TypeMachine");
                });

            modelBuilder.Entity("TankWiki.Models.ModelTank.Engine", b =>
                {
                    b.Navigation("TankEngines");
                });

            modelBuilder.Entity("TankWiki.Models.ModelTank.Gun", b =>
                {
                    b.Navigation("TurretGuns");
                });

            modelBuilder.Entity("TankWiki.Models.ModelTank.Radio", b =>
                {
                    b.Navigation("TankRadios");
                });

            modelBuilder.Entity("TankWiki.Models.ModelTank.Suspension", b =>
                {
                    b.Navigation("TankSuspensions");
                });

            modelBuilder.Entity("TankWiki.Models.ModelTank.Tank", b =>
                {
                    b.Navigation("TankEngines");

                    b.Navigation("TankRadios");

                    b.Navigation("TankSuspensions");

                    b.Navigation("TankTurrets");
                });

            modelBuilder.Entity("TankWiki.Models.ModelTank.Turret", b =>
                {
                    b.Navigation("TankTurrets");

                    b.Navigation("TurretGuns");
                });
#pragma warning restore 612, 618
        }
    }
}
