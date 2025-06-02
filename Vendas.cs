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
        private Carrinho carrinho;

        // CLASSE DOS PRODUTOS
        public class Produto
        {
            public string Nome { get; set; }
            public decimal Preco { get; set; }
            public int Quantidade { get; set; } = 1;

            public bool EhProdutoDeBalcao { get; set; } // true = balcão, false = cozinha

            public string Descricao => $"{Nome} - R$ {Preco:F2}";
            public string DescricaoCarrinho => $"{Quantidade}x {Nome} - R$ {Preco * Quantidade:F2}";
        }
        public Form1_Pedidos()
        {
            InitializeComponent();

            txtValorPago.Visible = false;
            txtTroco.Visible = false;
            labelV.Visible = false;
            labelT.Visible = false;

            carrinho = new Carrinho();

            pedidos = new List<Pedido>();

            produtos = new List<Produto>
            {
               new Produto { Nome = "Pão de Queijo", Preco = 3.50m, EhProdutoDeBalcao = true },
               new Produto { Nome = "Coxinha", Preco = 5.00m, EhProdutoDeBalcao = true },
               new Produto { Nome = "Pastel de Carne", Preco = 6.00m, EhProdutoDeBalcao = false },
               new Produto { Nome = "Pastel de Queijo", Preco = 5.50m, EhProdutoDeBalcao = false },
               new Produto { Nome = "Hamburger", Preco = 8.00m, EhProdutoDeBalcao = false },
               new Produto { Nome = "Cheese Burger", Preco = 9.00m, EhProdutoDeBalcao = false },
               new Produto { Nome = "X - Tudo", Preco = 12.00m, EhProdutoDeBalcao = false },
               new Produto { Nome = "Água Mineral", Preco = 2.50m, EhProdutoDeBalcao = true },
               new Produto { Nome = "Suco Natural 300ml", Preco = 4.00m, EhProdutoDeBalcao = true },
               new Produto { Nome = "Refrigerante Lata", Preco = 4.50m, EhProdutoDeBalcao = true },
               new Produto { Nome = "Milk Shake", Preco = 12.00m, EhProdutoDeBalcao = false },
            };

            cmbPagamento.Items.AddRange(new string[] { "Dinheiro", "Débito", "Crédito", "Pix", "VR", "VA" });

            listBox1.DataSource = produtos;
            listBox1.DisplayMember = "Descricao";

            listBox2.DisplayMember = "DescricaoCarrinho";
        }
        // Essa função serve apenas para alterar a fonte da message box
        public class FormMessageBox : Form
        {
            private Label lblMensagem;
            private Button btnOk;

            public FormMessageBox(string mensagem)
            {
                this.Text = "Pedido Finalizado";
                this.Size = new Size(350, 300); // Ajuste do tamanho da caixa
                this.StartPosition = FormStartPosition.CenterScreen;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;

                lblMensagem = new Label
                {
                    Text = mensagem,
                    Font = new Font("Arial", 12, FontStyle.Regular), // Fonte Arial 12 sem negrito
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft, // Texto justificado à esquerda
                    Dock = DockStyle.Top,
                    Height = 220, // Ajuste da altura do label
                    Padding = new Padding(10) // Espaçamento interno para melhor visualização
                };

                btnOk = new Button
                {
                    Text = "OK",
                    Size = new Size(80, 30), // Tamanho do botão
                    Location = new Point((this.Width - 80) / 2, this.Height - 80) // Ajuste da posição no final
                };

                btnOk.Anchor = AnchorStyles.Bottom; // Fixar o botão na parte inferior
                btnOk.Click += (sender, e) => this.Close();

                this.Controls.Add(lblMensagem);
                this.Controls.Add(btnOk);
            }

            public static void Show(string mensagem)
            {
                FormMessageBox form = new FormMessageBox(mensagem);
                form.ShowDialog();
            }
        }
        
        public class Carrinho
        {
            private List<Produto> itens = new List<Produto>();

            public void Adicionar(Produto produto)
            {
                Produto itemExistente = itens.FirstOrDefault(p => p.Nome == produto.Nome);

                if (itemExistente != null)
                {
                    itemExistente.Quantidade += produto.Quantidade;
                }
                else
                {
                    itens.Add(produto);
                }
            }

            public decimal Total() => itens.Sum(p => p.Preco * p.Quantidade);
            public List<Produto> Listar() => new List<Produto>(itens);
            public void Limpar() => itens.Clear();
        }

        private void AtualizarTotal()
        {
            lblTotal.Text = $"Total: R${carrinho.Total():F2}";

            listBox2.Items.Clear();
            foreach (var item in carrinho.Listar())
            {
                listBox2.Items.Add(item.DescricaoCarrinho);
            }
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Produto produto)
            {
                Produto novoProduto = new Produto
                {
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Quantidade = (int)numericUpDown.Value
                };

                carrinho.Adicionar(novoProduto);
                AtualizarTotal();
                numericUpDown.Value = 1;
            }
        }

        private void btnremover_Click_1(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                string itemSelecionado = listBox2.SelectedItem.ToString();
                Produto produtoRemover = carrinho.Listar().FirstOrDefault(p => p.DescricaoCarrinho == itemSelecionado);

                if (produtoRemover != null)
                {
                    carrinho.Listar().Remove(produtoRemover); // Isso não funciona

                    // Solução: Acesse diretamente a lista de itens da classe Carrinho
                    var itensCarrinho = typeof(Carrinho).GetField("itens", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(carrinho) as List<Produto>;

                    if (itensCarrinho != null)
                    {
                        itensCarrinho.Remove(produtoRemover);
                    }

                    AtualizarTotal();
                }
            }
        }

        private void btbEncerrar_Click(object sender, EventArgs e)
        {
            decimal totalPedido = carrinho.Total();
            string nome = string.IsNullOrWhiteSpace(nomeCliente.Text) ? "Cliente" : nomeCliente.Text;
            bool paraViagem = checkViagem.Checked;
            List<Produto> itensSelecionados = carrinho.Listar();
            string mensagem = $"Pedido de {nome}\nTotal do pedido: R$ {totalPedido:F2}";

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

                if (valorPago < totalPedido)
                {
                    MessageBox.Show("Valor insuficiente! Por favor, insira um valor maior ou igual ao total do pedido.", "Erro no Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal troco = valorPago - totalPedido;

                if (troco > 0) // Exibe o troco se houver
                {
                    mensagem += $"\nTroco: R$ {troco:F2}";
                }
            }

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
            FormMessageBox.Show(mensagem);

            // Limpar carrinho e atualizar a interface
            carrinho.Limpar();
            listBox2.Items.Clear();
            txtValorPago.Clear();
            txtTroco.Clear();
            nomeCliente.Clear();
            cmbPagamento.SelectedIndex = -1;
            txtValorPago.Visible = false;
            txtTroco.Visible = false;
            labelV.Visible = false;
            labelT.Visible = false;
            AtualizarTotal();
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
                txtValorPago.Text = string.Empty; // Limpa o campo se houver entrada inválida
                txtTroco.Text = "0.00"; // Reseta o troco
                return;
            }

            decimal totalPedido = carrinho.Total();
            decimal troco = Math.Max(0, valorPago - totalPedido);
            txtTroco.Text = troco.ToString("F2");
        }


        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem is Produto produto)
            {
                produto.Quantidade = (int)numericUpDown.Value;
                AtualizarTotal();
            }
        }

        private void btnAbre_Click(object sender, EventArgs e)
        {
            Balcao minhaNovaJanela = new Balcao(pedidos); // Passando a lista de pedidos
            minhaNovaJanela.Show();
        }

        private void btnExibe_Click(object sender, EventArgs e)
        {
            Balcao minhaNovaJanela = new Balcao(pedidos); // Passando a lista de pedidos
            minhaNovaJanela.Show();
        }
    }
}



