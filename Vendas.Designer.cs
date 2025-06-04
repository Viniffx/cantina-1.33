namespace Cantina_1._3
{
    partial class Form1_Pedidos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            lblTotal = new Label();
            btnAdicionar = new Button();
            btnremover = new Button();
            btbEncerrar = new Button();
            numericUpDown = new NumericUpDown();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            cmbPagamento = new ComboBox();
            labelV = new Label();
            labelT = new Label();
            txtValorPago = new TextBox();
            txtTroco = new TextBox();
            checkViagem = new CheckBox();
            nomeCliente = new TextBox();
            label4 = new Label();
            label5 = new Label();
            btnAbre = new Button();
            btnAbreCozinha = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(67, 153);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 0;
            label1.Text = "Produtos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(539, 153);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 1;
            label2.Text = "Carrinho";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(67, 174);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(231, 180);
            listBox1.TabIndex = 2;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(539, 174);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(231, 180);
            listBox2.TabIndex = 3;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(539, 357);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(94, 29);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total:  ";
            // 
            // btnAdicionar
            // 
            btnAdicionar.Font = new Font("Microsoft Sans Serif", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdicionar.Location = new Point(367, 270);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(111, 32);
            btnAdicionar.TabIndex = 5;
            btnAdicionar.Text = "Adicionar >";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click_1;
            // 
            // btnremover
            // 
            btnremover.Font = new Font("Microsoft Sans Serif", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnremover.Location = new Point(367, 308);
            btnremover.Name = "btnremover";
            btnremover.Size = new Size(111, 31);
            btnremover.TabIndex = 6;
            btnremover.Text = "< Remover";
            btnremover.UseVisualStyleBackColor = true;
            btnremover.Click += btnremover_Click_1;
            // 
            // btbEncerrar
            // 
            btbEncerrar.Font = new Font("Microsoft Sans Serif", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btbEncerrar.Location = new Point(549, 494);
            btbEncerrar.Name = "btbEncerrar";
            btbEncerrar.Size = new Size(139, 47);
            btbEncerrar.TabIndex = 7;
            btbEncerrar.Text = "Fechar Pedido";
            btbEncerrar.UseVisualStyleBackColor = true;
            btbEncerrar.Click += btbEncerrar_Click;
            // 
            // numericUpDown
            // 
            numericUpDown.Location = new Point(367, 242);
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(111, 22);
            numericUpDown.TabIndex = 9;
            numericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown.ValueChanged += numericUpDown_ValueChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Bolt_com_fundo_amarelo;
            pictureBox1.Location = new Point(-5, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(510, 135);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 42F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(17, 25, 12);
            label3.Location = new Point(429, 69);
            label3.Name = "label3";
            label3.Size = new Size(329, 64);
            label3.TabIndex = 11;
            label3.Text = "Lanchonete";
            // 
            // cmbPagamento
            // 
            cmbPagamento.FormattingEnabled = true;
            cmbPagamento.Location = new Point(367, 413);
            cmbPagamento.Name = "cmbPagamento";
            cmbPagamento.Size = new Size(121, 24);
            cmbPagamento.TabIndex = 12;
            cmbPagamento.SelectedIndexChanged += cmbPagamento_SelectedIndexChanged;
            // 
            // labelV
            // 
            labelV.AutoSize = true;
            labelV.Font = new Font("Microsoft Sans Serif", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelV.Location = new Point(309, 443);
            labelV.Name = "labelV";
            labelV.Size = new Size(56, 20);
            labelV.TabIndex = 13;
            labelV.Text = "Valor:";
            // 
            // labelT
            // 
            labelT.AutoSize = true;
            labelT.Font = new Font("Microsoft Sans Serif", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelT.Location = new Point(303, 471);
            labelT.Name = "labelT";
            labelT.Size = new Size(59, 20);
            labelT.TabIndex = 14;
            labelT.Text = "Troco:";
            // 
            // txtValorPago
            // 
            txtValorPago.Location = new Point(367, 443);
            txtValorPago.Name = "txtValorPago";
            txtValorPago.Size = new Size(121, 22);
            txtValorPago.TabIndex = 15;
            txtValorPago.TextChanged += txtValorPago_TextChanged;
            // 
            // txtTroco
            // 
            txtTroco.Location = new Point(367, 471);
            txtTroco.Name = "txtTroco";
            txtTroco.Size = new Size(121, 22);
            txtTroco.TabIndex = 16;
            // 
            // checkViagem
            // 
            checkViagem.AutoSize = true;
            checkViagem.Font = new Font("Microsoft Sans Serif", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkViagem.Location = new Point(549, 465);
            checkViagem.Name = "checkViagem";
            checkViagem.Size = new Size(130, 24);
            checkViagem.TabIndex = 17;
            checkViagem.Text = "Para Viagem";
            checkViagem.UseVisualStyleBackColor = true;
            // 
            // nomeCliente
            // 
            nomeCliente.Location = new Point(367, 197);
            nomeCliente.Name = "nomeCliente";
            nomeCliente.Size = new Size(111, 22);
            nomeCliente.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(364, 174);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 19;
            label4.Text = "Cliente: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(263, 413);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 20;
            label5.Text = "Pagamento:";
            // 
            // btnAbre
            // 
            btnAbre.Location = new Point(549, 561);
            btnAbre.Name = "btnAbre";
            btnAbre.Size = new Size(219, 47);
            btnAbre.TabIndex = 21;
            btnAbre.Text = "Ver balcão";
            btnAbre.UseVisualStyleBackColor = true;
            btnAbre.Click += btnAbre_Click;
            // 
            // btnAbreCozinha
            // 
            btnAbreCozinha.Location = new Point(354, 561);
            btnAbreCozinha.Name = "btnAbreCozinha";
            btnAbreCozinha.Size = new Size(171, 47);
            btnAbreCozinha.TabIndex = 22;
            btnAbreCozinha.Text = "Ver cozinha";
            btnAbreCozinha.UseVisualStyleBackColor = true;
            btnAbreCozinha.Click += btnAbreCozinha_Click;
            // 
            // Form1_Pedidos
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 255, 0);
            ClientSize = new Size(839, 620);
            Controls.Add(btnAbreCozinha);
            Controls.Add(btnAbre);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(nomeCliente);
            Controls.Add(checkViagem);
            Controls.Add(txtTroco);
            Controls.Add(txtValorPago);
            Controls.Add(labelT);
            Controls.Add(labelV);
            Controls.Add(cmbPagamento);
            Controls.Add(label3);
            Controls.Add(numericUpDown);
            Controls.Add(btbEncerrar);
            Controls.Add(btnremover);
            Controls.Add(btnAdicionar);
            Controls.Add(lblTotal);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Form1_Pedidos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pedidos";
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ListBox listBox1;
        private ListBox listBox2;
        private Label lblTotal;
        private Button btnAdicionar;
        private Button btnremover;
        private Button btbEncerrar;
        private NumericUpDown numericUpDown;
        private PictureBox pictureBox1;
        private Label label3;
        private ComboBox cmbPagamento;
        private Label labelV;
        private Label labelT;
        private TextBox txtValorPago;
        private TextBox txtTroco;
        private CheckBox checkViagem;
        private TextBox nomeCliente;
        private Label label4;
        private Label label5;
        private Button btnAbre;
        private Button btnAbreCozinha;
    }
}
