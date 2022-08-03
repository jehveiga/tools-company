using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueWeb.Models
{
    [Table("Cliente")]
    public class ClienteModel : UsuarioModel
    {
        [Required, Column(TypeName = "char(14)")]
        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        [NotMapped]
        public int Idade
        {
            get => (int)Math.Floor((DateTime.Now - DataNascimento).TotalDays / 365.2425);            
        }

        public ICollection<EnderecoModel> Enderecos { get; set; }

        public ICollection<PedidoModel> Pedidos { get; set; }
    }
}