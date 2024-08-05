using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TankWiki.Models.ModelOneToMany;
using TankWiki.Models.ModelTank;

namespace TankWiki.Models
{
    public class MySqlDBContext : DbContext
    {
        public MySqlDBContext(DbContextOptions<MySqlDBContext> options) : base(options) { }

        ////////////////////////////////  ModelTank
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Gun> Guns { get; set; }
        public DbSet<Radio> Radios { get; set; }
        public DbSet<Suspension> Suspensions { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<TankType> TankTypes { get; set; }
        public DbSet<Turret> Turrets { get; set; }
        public DbSet<Nations> Nations { get; set; }

        ////////////////////////////////  ModelOneToMany
        public DbSet<TurretGun> TurretGuns { get; set; }
        public DbSet<TankTurret> TankTurrets { get; set; }
        public DbSet<TankEngine> TankEngines { get; set; }
        public DbSet<TankSuspension> TankSuspensions { get; set; }
        public DbSet<TankRadio> TankRadios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            /////////////////////////// Tank
            modelBuilder.Entity<Tank>()
                .HasOne(t => t.TankType)
                .WithMany(tt => tt.Tanks)
                .HasForeignKey(t => t.TypeId);
            
            /// // Визначення відношення один-до-багатьох між Nation та Tank
            modelBuilder.Entity<Tank>()
                .HasOne(t => t.Nation)
                .WithMany(n => n.Tanks)
                .HasForeignKey(t => t.NationId);

            modelBuilder.Entity<Tank>()
               .HasOne(t => t.Armor)
               .WithOne(a => a.Tank)
               .HasForeignKey<Armor>(a => a.TankId);

            //////////////////////////   TankTurret
            modelBuilder.Entity<TankTurret>()
               .HasKey(tg => new { tg.TurretId, tg.TankId });

            modelBuilder.Entity<TankTurret>()
                .HasOne(tg => tg.Turret)
                .WithMany(t => t.TankTurrets)
                .HasForeignKey(tg => tg.TurretId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TankTurret>()
                .HasOne(tg => tg.Tank)
                .WithMany(g => g.TankTurrets)
                .HasForeignKey(tg => tg.TankId)
                .OnDelete(DeleteBehavior.Restrict);

            //////////////////////////   TurretGun
            modelBuilder.Entity<TurretGun>()
                .HasKey(tg => new { tg.TurretId, tg.GunId });

            modelBuilder.Entity<TurretGun>()
                .HasOne(tg => tg.Turret)
                .WithMany(t => t.TurretGuns)
                .HasForeignKey(tg => tg.TurretId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TurretGun>()
                .HasOne(tg => tg.Gun)
                .WithMany(g => g.TurretGuns)
                .HasForeignKey(tg => tg.GunId)
                .OnDelete(DeleteBehavior.Restrict);

            //////////////////////////    TankEngine

            modelBuilder.Entity<TankEngine>()
               .HasKey(te => new { te.EngineId, te.TankId });

            modelBuilder.Entity<TankEngine>()
                .HasOne(te => te.Engine)
                .WithMany(e => e.TankEngines)
                .HasForeignKey(te => te.EngineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TankEngine>()
                .HasOne(tg => tg.Tank)
                .WithMany(g => g.TankEngines)
                .HasForeignKey(tg => tg.TankId)
                .OnDelete(DeleteBehavior.Restrict);

            //////////////////////////   TankSuspension
            modelBuilder.Entity<TankSuspension>()
               .HasKey(ts => new { ts.SuspensionId, ts.TankId });

            modelBuilder.Entity<TankSuspension>()
                .HasOne(ts => ts.Suspension)
                .WithMany(s => s.TankSuspensions)
                .HasForeignKey(ts => ts.SuspensionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TankSuspension>()
                .HasOne(ts => ts.Tank)
                .WithMany(t => t.TankSuspensions)
                .HasForeignKey(ts => ts.TankId)
                .OnDelete(DeleteBehavior.Restrict);

            //////////////////////////   TankRadio
            modelBuilder.Entity<TankRadio>()
               .HasKey(ts => new { ts.RadioId, ts.TankId });

            modelBuilder.Entity<TankRadio>()
                .HasOne(tr => tr.Radio)
                .WithMany(r => r.TankRadios)
                .HasForeignKey(tr => tr.RadioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TankRadio>()
                .HasOne(ts => ts.Tank)
                .WithMany(t => t.TankRadios)
                .HasForeignKey(ts => ts.TankId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
    }
}
