namespace TopGames
{
    partial class FormAluguel
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
            this.label5 = new System.Windows.Forms.Label();
            this.btnNovoAlugel = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.cbxClientes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.cbxProdutos = new System.Windows.Forms.ComboBox();
            this.dgvVenda = new System.Windows.Forms.DataGridView();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnAttAluguel = new System.Windows.Forms.Button();
            this.btnAlugar = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.btnLocalizar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtEntrega = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtRetirada = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(219, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 29);
            this.label5.TabIndex = 121;
            this.label5.Text = "R$";
            // 
            // btnNovoAlugel
            // 
            this.btnNovoAlugel.BackColor = System.Drawing.Color.CadetBlue;
            this.btnNovoAlugel.Location = new System.Drawing.Point(283, 23);
            this.btnNovoAlugel.Name = "btnNovoAlugel";
            this.btnNovoAlugel.Size = new System.Drawing.Size(155, 23);
            this.btnNovoAlugel.TabIndex = 120;
            this.btnNovoAlugel.Text = "Iniciar locação";
            this.btnNovoAlugel.UseVisualStyleBackColor = false;
            this.btnNovoAlugel.Click += new System.EventHandler(this.btnNovoAlugel_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(15, 177);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(53, 17);
            this.checkBox2.TabIndex = 119;
            this.checkBox2.Text = "Artigo";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 118;
            this.label4.Text = "Selecione o tipo de produto";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 154);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(49, 17);
            this.checkBox1.TabIndex = 117;
            this.checkBox1.Text = "Jogo";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 116;
            this.label3.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(268, 276);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(173, 37);
            this.txtTotal.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 114;
            this.label2.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(14, 276);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(87, 20);
            this.txtQuantidade.TabIndex = 113;
            this.txtQuantidade.TextChanged += new System.EventHandler(this.txtQuantidade_TextChanged);
            // 
            // cbxClientes
            // 
            this.cbxClientes.FormattingEnabled = true;
            this.cbxClientes.Location = new System.Drawing.Point(15, 92);
            this.cbxClientes.Name = "cbxClientes";
            this.cbxClientes.Size = new System.Drawing.Size(423, 21);
            this.cbxClientes.TabIndex = 112;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 111;
            this.label1.Text = "Clientes";
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.LightBlue;
            this.btnLimpar.Location = new System.Drawing.Point(490, 337);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(264, 23);
            this.btnLimpar.TabIndex = 109;
            this.btnLimpar.Text = "Limpar Campos";
            this.btnLimpar.UseVisualStyleBackColor = false;
            // 
            // cbxProdutos
            // 
            this.cbxProdutos.FormattingEnabled = true;
            this.cbxProdutos.Location = new System.Drawing.Point(15, 203);
            this.cbxProdutos.Name = "cbxProdutos";
            this.cbxProdutos.Size = new System.Drawing.Size(423, 21);
            this.cbxProdutos.TabIndex = 108;
            // 
            // dgvVenda
            // 
            this.dgvVenda.AllowUserToAddRows = false;
            this.dgvVenda.AllowUserToDeleteRows = false;
            this.dgvVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVenda.GridColor = System.Drawing.Color.Thistle;
            this.dgvVenda.Location = new System.Drawing.Point(10, 451);
            this.dgvVenda.Name = "dgvVenda";
            this.dgvVenda.ReadOnly = true;
            this.dgvVenda.Size = new System.Drawing.Size(744, 251);
            this.dgvVenda.TabIndex = 107;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(636, 410);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(118, 23);
            this.btnVoltar.TabIndex = 106;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(490, 410);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(140, 23);
            this.btnDeletar.TabIndex = 105;
            this.btnDeletar.Text = "Deletar locação";
            this.btnDeletar.UseVisualStyleBackColor = true;
            // 
            // btnAttAluguel
            // 
            this.btnAttAluguel.BackColor = System.Drawing.Color.LightBlue;
            this.btnAttAluguel.Location = new System.Drawing.Point(490, 308);
            this.btnAttAluguel.Name = "btnAttAluguel";
            this.btnAttAluguel.Size = new System.Drawing.Size(264, 23);
            this.btnAttAluguel.TabIndex = 104;
            this.btnAttAluguel.Text = "Editar locação";
            this.btnAttAluguel.UseVisualStyleBackColor = false;
            // 
            // btnAlugar
            // 
            this.btnAlugar.BackColor = System.Drawing.Color.CadetBlue;
            this.btnAlugar.Location = new System.Drawing.Point(490, 279);
            this.btnAlugar.Name = "btnAlugar";
            this.btnAlugar.Size = new System.Drawing.Size(264, 23);
            this.btnAlugar.TabIndex = 103;
            this.btnAlugar.Text = "Alugar";
            this.btnAlugar.UseVisualStyleBackColor = false;
            this.btnAlugar.Click += new System.EventHandler(this.btnAlugar_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(15, 25);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(181, 20);
            this.txtID.TabIndex = 102;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(52, 13);
            this.lblID.TabIndex = 101;
            this.lblID.Text = "ID Venda";
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.BackColor = System.Drawing.Color.LightBlue;
            this.btnLocalizar.Location = new System.Drawing.Point(202, 23);
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(75, 23);
            this.btnLocalizar.TabIndex = 100;
            this.btnLocalizar.Text = "Localizar";
            this.btnLocalizar.UseVisualStyleBackColor = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.CadetBlue;
            this.btnConfirmar.Location = new System.Drawing.Point(490, 366);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(264, 38);
            this.btnConfirmar.TabIndex = 126;
            this.btnConfirmar.Text = "Confirmar entrega";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(268, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 130;
            this.label7.Text = "Entrega";
            // 
            // dtEntrega
            // 
            this.dtEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEntrega.Location = new System.Drawing.Point(270, 363);
            this.dtEntrega.Name = "dtEntrega";
            this.dtEntrega.Size = new System.Drawing.Size(133, 20);
            this.dtEntrega.TabIndex = 129;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 347);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 128;
            this.label6.Text = "Retirada";
            // 
            // dtRetirada
            // 
            this.dtRetirada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRetirada.Location = new System.Drawing.Point(14, 363);
            this.dtRetirada.Name = "dtRetirada";
            this.dtRetirada.Size = new System.Drawing.Size(133, 20);
            this.dtRetirada.TabIndex = 127;
            this.dtRetirada.ValueChanged += new System.EventHandler(this.dtRetirada_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(490, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 261);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 110;
            this.pictureBox1.TabStop = false;
            // 
            // FormAluguel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 714);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtEntrega);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtRetirada);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnNovoAlugel);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.cbxClientes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.cbxProdutos);
            this.Controls.Add(this.dgvVenda);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAttAluguel);
            this.Controls.Add(this.btnAlugar);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnLocalizar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAluguel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locação";
            this.Load += new System.EventHandler(this.FormAluguel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNovoAlugel;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.ComboBox cbxClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.ComboBox cbxProdutos;
        private System.Windows.Forms.DataGridView dgvVenda;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnAttAluguel;
        private System.Windows.Forms.Button btnAlugar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnLocalizar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtEntrega;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtRetirada;
    }
}