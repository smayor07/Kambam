using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Modelo.Classes;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistencia.Contexts
{
    class EFContext : DbContext //estende de DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());

        } /*este construtor estende ao contrutor da classe base.
        O argumento refere-se ao nome da connection string definida no arquivo Web.config */


        //resolve o problema da pluralização das tabelas
        //importar System.Data.Entity.ModelConfiguration.Conventions;
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Membro> Membro { get; set; }
        public DbSet<MemTar> MemTar { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Quadro> Quadro { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }

    }
}
