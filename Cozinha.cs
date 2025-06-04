using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Cantina_1._3.Form1_Pedidos; // Para acessar a classe Produto

namespace Cantina_1._3
{
    public partial class Cozinha : Form
    {
        private List<Pedido> pedidosCompletos;

        public Cozinha(List<Pedido> pedidosRecebidos)
        {
            InitializeComponent();
            pedidosCompletos = pedidosRecebidos ?? new List<Pedido>();
            AtualizarListaCozinha();
        }

        private void AtualizarListaCozinha()
        {
            listBox1.Items.Clear();

            // Esta linha é crucial: está pegando apenas os pedidos que TEM itens de cozinha.
            var pedidosParaCozinha = pedidosCompletos.Where(p => p.ItensCozinha.Any()).ToList();

            // ...
            foreach (var pedido in pedidosParaCozinha)
            {
                // Esta linha também é crucial: está exibindo APENAS os itens de cozinha.
                string itensCozinha = string.Join(", ", pedido.ItensCozinha.Select(item => $"{item.Quantidade}x {item.Nome}"));
                listBox1.Items.Add($"Cliente: {pedido.NomeCliente} | Itens (Cozinha): {itensCozinha} | Hora: {pedido.HoraPedido:HH:mm:ss}");
            }
        }

        private void btnPedidoPronto_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um pedido que está pronto.");
                return;
            }

            // Encontrar o pedido original (similar à lógica do Balcao)
            string linhaSelecionada = listBox1.SelectedItem.ToString();
            var pedidoSelecionado = pedidosCompletos.FirstOrDefault(p =>
                linhaSelecionada.Contains($"Cliente: {p.NomeCliente}") &&
                linhaSelecionada.Contains($"Hora: {p.HoraPedido:HH:mm:ss}"));

            if (pedidoSelecionado != null)
            {
                // Remove os itens de cozinha do pedido
                pedidoSelecionado.RemoverItensPorTipo(true); // true = é de cozinha

                // Se o pedido não tiver mais itens, remove ele da lista completa
                if (!pedidoSelecionado.Itens.Any())
                {
                    pedidosCompletos.Remove(pedidoSelecionado);
                }

                MessageBox.Show($"Pedido do(a) {pedidoSelecionado.NomeCliente} pronto para entrega!");
                AtualizarListaCozinha(); // Atualiza a lista da cozinha
                // NOTA: Se este pedido tinha itens de balcão que já estavam prontos,
                // eles ainda estarão na lista de pedidos do balcão, a menos que
                // o balcão tenha uma forma de ser notificado para atualizar sua lista.
                // Isso pode ser feito com eventos ou atualizando a lista do balcão
                // sempre que a cozinha marca um pedido como pronto.
            }
        }
    }
}