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
            btnLiberar = new Button();
            listBoxCozinha = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Bolt_com_fundo_amarelo;
            pictureBox1.Location = new Point(227, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(288, 87);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // btnLiberar
            // 
            btnLiberar.Font = new Font("Microsoft Sans Serif", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLiberar.Location = new Point(695, 171);
            btnLiberar.Name = "btnLiberar";
            btnLiberar.Size = new Size(93, 64);
            btnLiberar.TabIndex = 13;
            btnLiberar.Text = "Liberar";
            btnLiberar.UseVisualStyleBackColor = true;
            btnLiberar.Click += btnLiberar_Click;
            // 
            // listBoxCozinha
            // 
            listBoxCozinha.FormattingEnabled = true;
            listBoxCozinha.ItemHeight = 15;
            listBoxCozinha.Location = new Point(23, 120);
            listBoxCozinha.Name = "listBoxCozinha";
            listBoxCozinha.Size = new Size(666, 169);
            listBoxCozinha.TabIndex = 14;
            listBoxCozinha.SelectedIndexChanged += listBoxCozinha_SelectedIndexChanged;
            // 
            // Cozinha
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 255, 0);
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxCozinha);
            Controls.Add(btnLiberar);
            Controls.Add(pictureBox1);
            Name = "Cozinha";
            Text = "Cozinha";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnLiberar;
        private ListBox listBoxCozinha;
    }
}