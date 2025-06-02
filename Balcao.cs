using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cantina_1._3
{
    public partial class Balcao : Form
    {
        private List<Pedido> pedidos;

        public Balcao(List<Pedido> pedidosRecebidos)
        {
            InitializeComponent();
            pedidos = pedidosRecebidos ?? new List<Pedido>();
            AtualizarLista();
        }

        private void AtualizarLista()
        {
            listBox1.Items.Clear();

            // Filtra os pedidos que possuem itens de balcão
            var pedidosBalcao = pedidos
                .Select(p => new
                {
                    Pedido = p,
                    ItensBalcao = p.Itens.Where(item => item.EhProdutoDeBalcao).ToList()
                })
                .Where(p => p.ItensBalcao.Any()) // Pega apenas se tiver itens para o balcão
                .ToList();

            if (pedidosBalcao.Count == 0)
            {
                listBox1.Items.Add("Nenhum pedido para o balcão.");
                return;
            }

            foreach (var p in pedidosBalcao)
            {
                string itensPedido = string.Join(", ", p.ItensBalcao.Select(item => $"{item.Quantidade}x {item.Nome}"));

                listBox1.Items.Add(
                    $"Cliente: {p.Pedido.NomeCliente} | Itens: {itensPedido} | Hora: {p.Pedido.HoraPedido:HH:mm:ss} | Para: {(p.Pedido.ParaViagem ? "viagem" : "local")}"
                );
            }
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um pedido para entregar.");
                return;
            }

            // Filtra novamente para garantir que o índice corresponde à lista exibida
            var pedidosBalcao = pedidos
                .Select(p => new
                {
                    Pedido = p,
                    ItensBalcao = p.Itens.Where(item => item.EhProdutoDeBalcao).ToList()
                })
                .Where(p => p.ItensBalcao.Any())
                .ToList();

            if (listBox1.SelectedIndex >= pedidosBalcao.Count)
            {
                MessageBox.Show("Seleção inválida.");
                return;
            }

            var pedidoSelecionado = pedidosBalcao[listBox1.SelectedIndex];

            string itensPedido = string.Join(", ", pedidoSelecionado.ItensBalcao.Select(item => $"{item.Quantidade}x {item.Nome}"));

            listBox2.Items.Insert(0,
                $"Cliente: {pedidoSelecionado.Pedido.NomeCliente} | Itens: {itensPedido} | Hora: {pedidoSelecionado.Pedido.HoraPedido:HH:mm:ss} | Para viagem: {(pedidoSelecionado.Pedido.ParaViagem ? "Sim" : "Não")}"
            );

            if (listBox2.Items.Count > 3)
            {
                listBox2.Items.RemoveAt(3);
            }

            // Remove apenas os itens do balcão do pedido
            foreach (var item in pedidoSelecionado.ItensBalcao)
            {
                pedidoSelecionado.Pedido.Itens.Remove(item);
            }

            // Se o pedido ficou vazio (sem itens de balcão nem de cozinha), remove ele da lista de pedidos
            if (!pedidoSelecionado.Pedido.Itens.Any())
            {
                pedidos.Remove(pedidoSelecionado.Pedido);
            }

            AtualizarLista();
        }
    }
}
