namespace Cantina_1._3
{
    partial class Cozinha
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            btnPedidoPronto = new Button();
            listBox1 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Bolt_com_fundo_amarelo;
            pictureBox1.Location = new Point(242, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(288, 87);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // btnPedidoPronto
            // 
            btnPedidoPronto.Location = new Point(691, 178);
            btnPedidoPronto.Name = "btnPedidoPronto";
            btnPedidoPronto.Size = new Size(89, 59);
            btnPedidoPronto.TabIndex = 14;
            btnPedidoPronto.Text = "Liberar Pedido";
            btnPedidoPronto.UseVisualStyleBackColor = true;
//            btnPedidoPronto.Click += btnPedidoPronto_Click_1;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(21, 143);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(653, 169);
            listBox1.TabIndex = 15;
            // 
            // Cozinha
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 255, 0);
            ClientSize = new Size(811, 450);
            Controls.Add(listBox1);
            Controls.Add(btnPedidoPronto);
            Controls.Add(pictureBox1);
            Name = "Cozinha";
            Text = "Cozinha";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnPedidoPronto;
        private ListBox listBox1;
    }
}