using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cantina_1._3.Form1_Pedidos;

namespace Cantina_1._3
{
    public class Pedido
    {
        public string NomeCliente { get; set; }
        public List<Produto> Itens { get; set; }
        public DateTime HoraPedido { get; private set; }
        public bool ParaViagem { get; set; }

        public Pedido(string nomeCliente, List<Produto> itens, bool paraViagem)
        {
            NomeCliente = string.IsNullOrWhiteSpace(nomeCliente) ? "Cliente" : nomeCliente;
            HoraPedido = DateTime.Now;
            ParaViagem = paraViagem;

            // Cria uma cópia real dos itens, incluindo EhProdutoDeBalcao
            Itens = itens.Select(p => new Produto
            {
                Nome = p.Nome,
                Preco = p.Preco,
                Quantidade = p.Quantidade,
                EhProdutoDeBalcao = p.EhProdutoDeBalcao
            }).ToList();
        }
    }
}
