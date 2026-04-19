using Microsoft.EntityFrameworkCore;
using EFProject.Models;

namespace EFProject.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<ItemEstoque> ItensEstoque { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = "server=localhost;database=escola;user=root;password=positivo";
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}