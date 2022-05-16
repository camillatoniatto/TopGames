
namespace TopGames
{
    partial class FormJogo
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
            this.dtpDataCadastro = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.txtEditora = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblEditora = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.DgvJogos = new System.Windows.Forms.DataGridView();
            this.lblLocalizar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvJogos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDataCadastro
            // 
            this.dtpDataCadastro.Location = new System.Drawing.Point(15, 305);
            this.dtpDataCadastro.Name = "dtpDataCadastro";
            this.dtpDataCadastro.Size = new System.Drawing.Size(219, 20);
            this.dtpDataCadastro.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Data do Cadastro";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(15, 253);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(114, 20);
            this.txtQuantidade.TabIndex = 77;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(12, 237);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(62, 13);
            this.lblQuantidade.TabIndex = 76;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(15, 204);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(114, 20);
            this.txtValor.TabIndex = 75;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(12, 188);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(31, 13);
            this.lblValor.TabIndex = 74;
            this.lblValor.Text = "Valor";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(459, 505);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 73;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(459, 111);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 72;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(459, 79);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 71;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(459, 16);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrar.TabIndex = 70;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // txtEditora
            // 
            this.txtEditora.Location = new System.Drawing.Point(15, 156);
            this.txtEditora.Name = "txtEditora";
            this.txtEditora.Size = new System.Drawing.Size(184, 20);
            this.txtEditora.TabIndex = 69;
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(15, 117);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(184, 20);
            this.txtCategoria.TabIndex = 68;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(15, 75);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(378, 20);
            this.txtNome.TabIndex = 67;
            // 
            // lblEditora
            // 
            this.lblEditora.AutoSize = true;
            this.lblEditora.Location = new System.Drawing.Point(12, 140);
            this.lblEditora.Name = "lblEditora";
            this.lblEditora.Size = new System.Drawing.Size(40, 13);
            this.lblEditora.TabIndex = 66;
            this.lblEditora.Text = "Editora";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(12, 101);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblCategoria.TabIndex = 65;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(12, 59);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 64;
            this.lblNome.Text = "Nome";
            // 
            // DgvJogos
            // 
            this.DgvJogos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvJogos.Location = new System.Drawing.Point(12, 348);
            this.DgvJogos.Name = "DgvJogos";
            this.DgvJogos.Size = new System.Drawing.Size(522, 138);
            this.DgvJogos.TabIndex = 63;
            // 
            // lblLocalizar
            // 
            this.lblLocalizar.Location = new System.Drawing.Point(459, 49);
            this.lblLocalizar.Name = "lblLocalizar";
            this.lblLocalizar.Size = new System.Drawing.Size(75, 23);
            this.lblLocalizar.TabIndex = 62;
            this.lblLocalizar.Text = "Localizar";
            this.lblLocalizar.UseVisualStyleBackColor = true;
            this.lblLocalizar.Click += new System.EventHandler(this.lblLocalizar_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(15, 37);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(184, 20);
            this.txtId.TabIndex = 61;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 21);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 60;
            this.lblId.Text = "Id";
            // 
            // FormJogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 541);
            this.Controls.Add(this.dtpDataCadastro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtEditora);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblEditora);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.DgvJogos);
            this.Controls.Add(this.lblLocalizar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormJogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jogos";
            ((System.ComponentModel.ISupportInitialize)(this.DgvJogos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDataCadastro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.TextBox txtEditora;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblEditora;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.DataGridView DgvJogos;
        private System.Windows.Forms.Button lblLocalizar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
    }
}