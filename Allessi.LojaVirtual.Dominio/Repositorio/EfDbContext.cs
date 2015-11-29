using Allessi.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allessi.LojaVirtual.Dominio.Repositorio
{
    public class EfDbContext : DbContext
    {
        // DBSet representa as entidades no contexto
        public DbSet<Produto> Produtos { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Trabalha com pluralização, que é transformar a tabela do banco de dados com o nome no plural.
            // Exemplo: tranforma a entidade Pessoa em Pessoas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Produto>().ToTable("Produto");
        }
    }
}
