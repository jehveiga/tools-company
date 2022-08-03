using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EstoqueWeb.Models
{
    public class EstoqueWebContext : DbContext
    {
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<ItemPedidoModel> ItensPedidos { get; set; }        

        public EstoqueWebContext(DbContextOptions<EstoqueWebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaModel>().ToTable("Categoria");
            modelBuilder.Entity<ProdutoModel>().ToTable("Produto");
            modelBuilder.Entity<ClienteModel>()
                .OwnsMany(c => c.Enderecos, e => 
                {
                    e.WithOwner().HasForeignKey("IdUsuario");
                    e.HasKey("IdUsuario", "IdEndereco");
                });
            modelBuilder.Entity<UsuarioModel>().Property(u => u.DataCadastro)
                .HasDefaultValueSql("datetime('now', 'localtime', 'start of day')")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            modelBuilder.Entity<ProdutoModel>().Property(p => p.Estoque)
                .HasDefaultValue(0);
            modelBuilder.Entity<PedidoModel>()
                .OwnsOne(p => p.EnderecoEntrega, e =>
                {
                    e.Ignore(e => e.IdEndereco);
                    e.Ignore(e => e.Selecionado);
                    e.ToTable("Pedido");
                });
            modelBuilder.Entity<ItemPedidoModel>()
                .HasKey(ip => new { ip.IdPedido, ip.IdProduto });
        }
    }
}