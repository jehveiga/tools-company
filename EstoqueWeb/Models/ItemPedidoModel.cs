using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueWeb.Models
{
    [Table("ItemPedido")]
    public class ItemPedidoModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPedido { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProduto { get; set; }

        public int Quantidade { get; set; }

        public double ValorUnitario { get; set; }

        [ForeignKey("IdPedido")]
        public PedidoModel Pedido { get; set; }

        [ForeignKey("IdProduto")]
        public ProdutoModel Produto { get; set; }

        [NotMapped]
        public double ValorItem { get => this.Quantidade * this.ValorUnitario; }
    }
}