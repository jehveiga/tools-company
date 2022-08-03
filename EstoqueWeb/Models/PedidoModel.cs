using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueWeb.Models
{
    [Table("Pedido")]
    public class PedidoModel
    {
        [Key]
        public int IdPedido { get; set; }

        public DateTime? DataPedido { get; set; }

        public DateTime? DataEntrega { get; set; }

        public double? ValorTotal { get; set; }

        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public ClienteModel Cliente { get; set; }

        public EnderecoModel EnderecoEntrega { get; set; }

        public ICollection<ItemPedidoModel> ItensPedido { get; set; }
    }
}