// Tela do Balcao
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cantina_1._3
{
    public partial class Balcao : Form
    {
        private List<Pedido> pedidosCompletos; // Esta lista ainda contém *todos* os pedidos

        public Balcao(List<Pedido> pedidosRecebidos)
        {
            InitializeComponent();
            pedidosCompletos = pedidosRecebidos ?? new List<Pedido>();
            this.Activated += Balcao_Activated;
            AtualizarLista();
        }

        private void Balcao_Activated(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void AtualizarLista()
        {
            listBox1.Items.Clear();

            // Esta linha é crucial: está pegando apenas os pedidos que TEM itens de balcão.
            var pedidosParaBalcao = pedidosCompletos.Where(p => p.ItensBalcao.Any()).ToList();

            // ...
            foreach (var pedido in pedidosParaBalcao)
            {
                // Esta linha também é crucial: está exibindo APENAS os itens de balcão.
                string itensBalcao = string.Join(", ", pedido.ItensBalcao.Select(item => $"{item.Quantidade}x {item.Nome}"));
                listBox1.Items.Add($"Cliente: {pedido.NomeCliente} | Itens (Balcão): {itensBalcao} | Hora: {pedido.HoraPedido:HH:mm:ss} | Para: {(pedido.ParaViagem ? "viagem" : "local")}");
            }
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um pedido para entregar.");
                return;
            }

            // Encontrar o pedido original (ainda é necessário se a ListBox não estiver ligada diretamente ao DataSource)
            string linhaSelecionada = listBox1.SelectedItem.ToString();
            // Lógica para encontrar o Pedido selecionado na lista 'pedidosCompletos'
            // Uma forma mais robusta seria usar um ID único para o Pedido.
            // Por enquanto, vamos tentar pela combinação de cliente e hora, que pode não ser única em cenários de alta demanda.
            var pedidoSelecionado = pedidosCompletos.FirstOrDefault(p =>
                linhaSelecionada.Contains($"Cliente: {p.NomeCliente}") &&
                linhaSelecionada.Contains($"Hora: {p.HoraPedido:HH:mm:ss}"));

            if (pedidoSelecionado != null)
            {
                // Formata os itens do pedido entregue (para o histórico de entregues)
                string itensPedidoEntregue = string.Join(", ", pedidoSelecionado.ItensBalcao.Select(item => $"{item.Quantidade}x {item.Nome}"));

                // Adiciona o pedido à listBox2 (mantendo apenas os 3 últimos)
                listBox2.Items.Insert(0, $"Cliente: {pedidoSelecionado.NomeCliente} | Entregue (Balcão): {itensPedidoEntregue} | Hora: {pedidoSelecionado.HoraPedido:HH:mm:ss} | Para viagem: {(pedidoSelecionado.ParaViagem ? "Sim" : "Não")}");

                if (listBox2.Items.Count > 3)
                {
                    listBox2.Items.RemoveAt(3); // Remove o mais antigo
                }

                // Remove os itens de balcão do pedido original
                pedidoSelecionado.RemoverItensPorTipo(false); // false = não é de cozinha (é de balcão)

                // Se o pedido não tiver mais itens (balcão e cozinha já entregues/preparados), então remove ele da lista completa
                if (!pedidoSelecionado.Itens.Any())
                {
                    pedidosCompletos.Remove(pedidoSelecionado);
                }

                AtualizarLista(); // Atualiza a lista de pedidos pendentes do balcão
            }
        }
    }
}