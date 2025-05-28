namespace Cantina_1._3
{
    partial class Balcao
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
            components = new System.ComponentModel.Container();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            label1 = new Label();
            btnEntregar = new Button();
            imageList1 = new ImageList(components);
            pictureBox1 = new PictureBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(32, 139);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(637, 157);
            listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            listBox2.Enabled = true;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 17;
            listBox2.Location = new Point(32, 347);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(637, 174);
            listBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Inter", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 108);
            label1.Name = "label1";
            label1.Size = new Size(72, 19);
            label1.TabIndex = 2;
            label1.Text = "Pedidos";
            // 
            // btnEntregar
            // 
            btnEntregar.Font = new Font("Inter", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEntregar.Location = new Point(675, 187);
            btnEntregar.Name = "btnEntregar";
            btnEntregar.Size = new Size(93, 73);
            btnEntregar.TabIndex = 4;
            btnEntregar.Text = "Entregar";
            btnEntregar.UseVisualStyleBackColor = true;
            btnEntregar.Click += btnEntregar_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Bolt_com_fundo_amarelo;
            pictureBox1.Location = new Point(226, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(288, 99);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Inter", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(32, 325);
            label3.Name = "label3";
            label3.Size = new Size(82, 19);
            label3.TabIndex = 12;
            label3.Text = "Entregue";
            // 
            // Balcao
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 255, 0);
            ClientSize = new Size(789, 548);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(btnEntregar);
            Controls.Add(label1);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            ForeColor = SystemColors.ControlText;
            Name = "Balcao";
            Text = "Balcao";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private ListBox listBox2;
        private Label label1;
        private Button btnEntregar;
        private ImageList imageList1;
        private PictureBox pictureBox1;
        private Label label3;
    }
}