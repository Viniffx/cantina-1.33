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

            if (pedidos.Count == 0)
            {
                listBox1.Items.Add("Nenhum pedido realizado.");
                return;
            }

            foreach (var pedido in pedidos)
            {
                // Criar uma única linha para exibir o pedido completo
                string itensPedido = string.Join(", ", pedido.Itens.Select(item => $"{item.Quantidade}x {item.Nome}"));

                // Adicionar o pedido formatado em uma única linha
                listBox1.Items.Add($"Cliente: {pedido.NomeCliente} | Itens: {itensPedido}  | Hora: {pedido.HoraPedido:HH:mm:ss} | Para: {(pedido.ParaViagem ? "viagem" : "local")}");
            }

        }
        private void btnEntregar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um pedido para entregar.");
                return;
            }

            // Obtém o pedido selecionado
            Pedido pedidoSelecionado = pedidos[listBox1.SelectedIndex];

            // Formata os itens do pedido
            string itensPedido = string.Join(", ", pedidoSelecionado.Itens.Select(item => $"{item.Quantidade}x {item.Nome}"));

            // Adiciona o pedido à listBox2 (mantendo apenas os 3 últimos)
            listBox2.Items.Insert(0, $"Cliente: {pedidoSelecionado.NomeCliente} | Itens: {itensPedido} | Hora: {pedidoSelecionado.HoraPedido:HH:mm:ss} | Para viagem: {(pedidoSelecionado.ParaViagem ? "Sim" : "Não")}");

            if (listBox2.Items.Count > 3)
            {
                listBox2.Items.RemoveAt(3); // Remove o mais antigo
            }

            // Remove o pedido entregue da lista original
            pedidos.RemoveAt(listBox1.SelectedIndex);

            // Atualiza a lista apenas se ainda houver pedidos
            if (pedidos.Any())
            {
                AtualizarLista();
            }
            else
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Nenhum pedido realizado.");
            }
        }
    }
}