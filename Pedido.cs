// Classe Pedido.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cantina_1._3
{
    public class Pedido
    {
        public string NomeCliente { get; set; }
        public List<Produto> Itens { get; set; }

        // ItensBalcao: SÃO aqueles onde ItemCozinha é FALSE (ou seja, NÃO é de cozinha)
        public List<Produto> ItensBalcao => Itens.Where(item => !item.ItemCozinha).ToList();

        // ItensCozinha: SÃO aqueles onde ItemCozinha é TRUE
        public List<Produto> ItensCozinha => Itens.Where(item => item.ItemCozinha).ToList();

        public DateTime HoraPedido { get; private set; }
        public bool ParaViagem { get; set; }

        public Pedido(string nomeCliente, List<Produto> itens, bool paraViagem)
        {
            NomeCliente = string.IsNullOrWhiteSpace(nomeCliente) ? "Cliente" : nomeCliente;
            Itens = new List<Produto>(itens);
            HoraPedido = DateTime.Now;
            ParaViagem = paraViagem;
        }

        public bool TemItensCozinha => ItensCozinha.Any();
        public bool TemItensBalcao => ItensBalcao.Any();

        public void RemoverItensPorTipo(bool ehDeCozinha)
        {
            Itens.RemoveAll(item => item.ItemCozinha == ehDeCozinha);
        }
    }
}