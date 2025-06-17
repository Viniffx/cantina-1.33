using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Cantina_1._3
{
    public partial class Form1_Pedidos : Form
    {
        private List<Pedido> pedidos;
        private List<Produto> produtos;
        private List<Produto> carrinho; // Nova lista para o carrinho

        public Form1_Pedidos()
        {
            InitializeComponent();

            txtValorPago.Visible = false;
            txtTroco.Visible = false;
            labelV.Visible = false;
            labelT.Visible = false;

            carrinho = new List<Produto>(); 

            pedidos = new List<Pedido>();

            produtos = new List<Produto>
            {
                new Produto { Nome = "Pão de Queijo", Preco = 3.50m, ItemCozinha = false }, // Balcão
                new Produto { Nome = "Coxinha", Preco = 5.00m, ItemCozinha = false }, // Balcão
                new Produto { Nome = "Pastel de Carne", Preco = 6.00m, ItemCozinha = true }, // Cozinha
                new Produto { Nome = "Pastel de Queijo", Preco = 5.50m, ItemCozinha = true }, // Cozinha
                new Produto { Nome = "Hamburger", Preco = 8.00m, ItemCozinha = true }, // Cozinha
                new Produto { Nome = "Cheese Burger", Preco = 9.00m, ItemCozinha = true }, // Cozinha
                new Produto { Nome = "X - Tudo", Preco = 12.00m, ItemCozinha = true }, // Cozinha
                new Produto { Nome = "Água Mineral", Preco = 2.50m, ItemCozinha = false }, // Balcão
                new Produto { Nome = "Suco Natural 300ml", Preco = 4.00m, ItemCozinha = false }, // Balcão
                new Produto { Nome = "Refrigerante Lata", Preco = 4.50m, ItemCozinha = false }, // Balcão
                new Produto { Nome = "Milk Shake", Preco = 12.00m, ItemCozinha = true }, // Cozinha
            };

            cmbPagamento.Items.AddRange(new string[] { "Dinheiro", "Débito", "Crédito", "Pix", "VR", "VA" });

            listBox1.DataSource = produtos;
            listBox1.DisplayMember = "Descricao";

            // Configura o carrinho com DataSource
            listCarrinho.DataSource = carrinho;
            listCarrinho.DisplayMember = "DescricaoCarrinho";
        }
        decimal total = 0;
        public void Adicionar(Produto produtoSelecionado)
        {
            // Procura se o produto já existe no carrinho
            Produto produtoExistente = carrinho.FirstOrDefault(p => p.Nome == produtoSelecionado.Nome);

            if (produtoExistente != null)
            {
                // Se existe, aumenta a quantidade
                produtoExistente.Quantidade += produtoSelecionado.Quantidade;
            }
            else
            {
                // Se não existe, adiciona novo produto
                carrinho.Add(produtoSelecionado);
            }

            // Atualiza a exibição
            AtualizarCarrinho();
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Produto produtoOriginal = (Produto)listBox1.SelectedItem;

                // Cria uma cópia do produto para o carrinho
                Produto produtoCarrinho = new Produto
                {
                    Nome = produtoOriginal.Nome,
                    Preco = produtoOriginal.Preco,
                    ItemCozinha = produtoOriginal.ItemCozinha,
                    Quantidade = (int)numericUpDown.Value
                };

                Adicionar(produtoCarrinho);
                total += produtoCarrinho.Preco * produtoCarrinho.Quantidade;
                lblTotal.Text = $"Total: R$ {total:F2}";
                numericUpDown.Value = 1;
            }
        }

        private void AtualizarCarrinho()
        {
            // Força a atualização do ListBox
            listCarrinho.DataSource = null;
            listCarrinho.DataSource = carrinho;
            listCarrinho.DisplayMember = "DescricaoCarrinho";
        }

        private void btnremover_Click_1(object sender, EventArgs e)
        {
            if (listCarrinho.SelectedItem != null)
            {
                Produto produto = (Produto)listCarrinho.SelectedItem;
                carrinho.Remove(produto);
                total -= produto.Preco * produto.Quantidade;
                lblTotal.Text = $"Total: R$ {total:F2}";
                AtualizarCarrinho();
                numericUpDown.Value = 1;
            }
        }

        private void btbEncerrar_Click(object sender, EventArgs e)
        {
            string nome = string.IsNullOrWhiteSpace(nomeCliente.Text) ? "Cliente" : nomeCliente.Text;
            bool paraViagem = checkViagem.Checked;
            string mensagem = $"Pedido de {nome}\nTotal do pedido: R$ {total:F2}";

            if (cmbPagamento.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma forma de pagamento antes de finalizar o pedido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Impede o encerramento do pedido sem pagamento selecionado
            }

            // Verifica se o pagamento foi em dinheiro e se o valor pago é suficiente
            if (cmbPagamento.SelectedItem?.ToString() == "Dinheiro")
            {
                if (string.IsNullOrWhiteSpace(txtValorPago.Text) || !decimal.TryParse(txtValorPago.Text, out decimal valorPago))
                {
                    MessageBox.Show("Insira um valor válido para o pagamento!", "Erro no Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (valorPago < total)
                {
                    MessageBox.Show("Valor insuficiente! Por favor, insira um valor maior ou igual ao total do pedido.", "Erro no Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal troco = valorPago - total;

                if (troco > 0) // Exibe o troco se houver
                {
                    mensagem += $"\nTroco: R$ {troco:F2}";
                }
            }

            // CORRIGIDO: Usar a lista carrinho em vez de listCarrinho.Items
            List<Produto> itensSelecionados = new List<Produto>(carrinho);

            // Adiciona a data e hora do pedido
            mensagem += $"\nData e Hora: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";

            // Verifica se o pedido é para viagem
            if (paraViagem)
            {
                mensagem += "\nPedido para viagem";
            }

            // Criando novo pedido e armazenando na lista
            Pedido novoPedido = new Pedido(nome, itensSelecionados, paraViagem);
            pedidos.Add(novoPedido);

            // Exibir resumo do pedido
            MessageBox.Show(mensagem);

            // CORRIGIDO: Limpar carrinho corretamente
            LimparCarrinho();
        }

        private void LimparCarrinho()
        {
            carrinho.Clear();
            AtualizarCarrinho();
            txtValorPago.Clear();
            txtTroco.Clear();
            nomeCliente.Clear();
            cmbPagamento.SelectedIndex = -1;
            txtValorPago.Visible = false;
            txtTroco.Visible = false;
            labelV.Visible = false;
            labelT.Visible = false;
            total = 0;
            lblTotal.Text = "Total:";
        }

        private void cmbPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool dinheiro = cmbPagamento.SelectedItem?.ToString() == "Dinheiro";
            txtValorPago.Visible = dinheiro;
            txtTroco.Visible = dinheiro;
            labelV.Visible = dinheiro;
            labelT.Visible = dinheiro;
        }

        private void txtValorPago_TextChanged(object sender, EventArgs e)
        {
            // Remove caracteres inválidos e mantém apenas números e o ponto decimal
            if (!decimal.TryParse(txtValorPago.Text, out decimal valorPago))
            {
                txtTroco.Text = "0.00"; // Reseta o troco
                return;
            }

            decimal troco = Math.Max(0, valorPago - total);
            txtTroco.Text = troco.ToString("F2");
        }

        private void btnBalcao_Click(object sender, EventArgs e)
        {
            Balcao minhaNovaJanela = new Balcao(pedidos); // Passando a lista de pedidos
            minhaNovaJanela.Show();
        }

        private void btnAbreCozinha_Click(object sender, EventArgs e)
        {
            // Crie a nova janela da cozinha e passe a mesma lista de pedidos
            Cozinha formCozinha = new Cozinha(pedidos);
            formCozinha.Show();
        }
    }
}