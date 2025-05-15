using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class MyDBContext : DbContext
    {
        public DbSet<Turrets> Turrets { get; set; }

        //Aggiunta di Machine e MachineTool
        public DbSet<Machines> Machines { get; set; }

        //Aggiunta di MachineTools
        public DbSet<MachineTools> MachineTools { get; set; }

        //Aggiunta di Tools
        public DbSet<Tools> Tools { get; set; }

        //Aggiunta di PartNumbers
        public DbSet<PartNumbers> PartNumbers { get; set; }


        public MyDBContext() : base("name=ToolsConnectionString") //collegamento database prende stringa connessione nell'app.config
        {
            Database.Log = sql => Debug.Write(sql); //configura il contesto del database (MyDBContext) per registrare tutte le query SQL generate da Entity Framework. In particolare, utilizza il metodo Debug.Write per scrivere queste query nella finestra di output del debugger
        }

        //mappatura tabella Turrets, Machine, MachineTools e Tools
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Config");

            modelBuilder.Entity<Turrets>().ToTable("Turrets");

            modelBuilder.Entity<Turrets>().HasKey(p => new { p.TurretCode });

            //Machine
            modelBuilder.Entity<Machines>().ToTable("Machines");

            modelBuilder.Entity<Machines>().HasKey(p => new { p.MachineCode });

            //MachineTools
            modelBuilder.Entity<MachineTools>().ToTable("MachineTools");

            modelBuilder.Entity<MachineTools>().HasKey(p => new { p.IdTool });

            //Tools
            modelBuilder.Entity<Tools>().ToTable("Tools");

            modelBuilder.Entity<Tools>().HasKey(p => new { p.IdTool });

            //Cofigurazione della nuova proprietà ToolType
            modelBuilder.Entity<Tools>().Property(t => t.ToolType).IsOptional();

            //Criteri di collegamento tra Machines e Tools
            /*
            modelBuilder.Entity<Machines>()
                
                .HasMany(m => m.Tools)
                .WithOptional(t => t.MachineTools)
                .HasForeignKey(t => t.Machine);
            */

            //Mappatura di PartNumbers            
            modelBuilder.Entity<PartNumbers>().ToTable("PartNumbers");

            //Configurazione della chiave primaria
            modelBuilder.Entity<PartNumbers>().HasKey(p => p.Code);           

            base.OnModelCreating(modelBuilder);

            //Relazione tra Tools e Turrets tramite TurretCode
            modelBuilder.Entity<Tools>()
                .HasOptional(t => t.Turret)
                .WithMany()
                .HasForeignKey(t => t.TurretCode);
        }
    }


        
}
