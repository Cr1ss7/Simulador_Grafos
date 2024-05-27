namespace Guia10_EJE1
{
    partial class Simulador
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Pizarra = new System.Windows.Forms.Panel();
            this.CMSCrearVertice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoVérticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminarArc = new System.Windows.Forms.Button();
            this.CBArco = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEliminarVer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CBVertice = new System.Windows.Forms.ComboBox();
            this.Recorrido = new System.Windows.Forms.GroupBox();
            this.btnAnch = new System.Windows.Forms.Button();
            this.btnProf = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CBNodoPartida = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDistancia = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRecorrido = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CBNodo2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CBNodo1 = new System.Windows.Forms.ComboBox();
            this.CMSCrearVertice.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Recorrido.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(575, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Simulador de Grafos";
            // 
            // Pizarra
            // 
            this.Pizarra.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Pizarra.Location = new System.Drawing.Point(312, 61);
            this.Pizarra.Name = "Pizarra";
            this.Pizarra.Size = new System.Drawing.Size(741, 343);
            this.Pizarra.TabIndex = 1;
            this.Pizarra.Paint += new System.Windows.Forms.PaintEventHandler(this.Pizarra_Paint);
            this.Pizarra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseDown);
            this.Pizarra.MouseLeave += new System.EventHandler(this.Pizarra_MouseLeave);
            this.Pizarra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseMove);
            this.Pizarra.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseUp);
            // 
            // CMSCrearVertice
            // 
            this.CMSCrearVertice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoVérticeToolStripMenuItem});
            this.CMSCrearVertice.Name = "CMSCrearVertice";
            this.CMSCrearVertice.Size = new System.Drawing.Size(148, 26);
            this.CMSCrearVertice.Opening += new System.ComponentModel.CancelEventHandler(this.CMSCrearVertice_Opening);
            this.CMSCrearVertice.Click += new System.EventHandler(this.CMSCrearVertice_Click);
            // 
            // nuevoVérticeToolStripMenuItem
            // 
            this.nuevoVérticeToolStripMenuItem.Name = "nuevoVérticeToolStripMenuItem";
            this.nuevoVérticeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.nuevoVérticeToolStripMenuItem.Text = "Nuevo Vértice";
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRespuesta.Location = new System.Drawing.Point(493, 417);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(331, 25);
            this.lblRespuesta.TabIndex = 2;
            this.lblRespuesta.Text = "Click derecho para crear un nodo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEliminarArc);
            this.groupBox1.Controls.Add(this.CBArco);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnEliminarVer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CBVertice);
            this.groupBox1.Location = new System.Drawing.Point(23, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 129);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnEliminarArc
            // 
            this.btnEliminarArc.Location = new System.Drawing.Point(200, 69);
            this.btnEliminarArc.Name = "btnEliminarArc";
            this.btnEliminarArc.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarArc.TabIndex = 5;
            this.btnEliminarArc.Text = "Eliminar";
            this.btnEliminarArc.UseVisualStyleBackColor = true;
            this.btnEliminarArc.Click += new System.EventHandler(this.btnEliminarArc_Click);
            // 
            // CBArco
            // 
            this.CBArco.FormattingEnabled = true;
            this.CBArco.Location = new System.Drawing.Point(77, 71);
            this.CBArco.Name = "CBArco";
            this.CBArco.Size = new System.Drawing.Size(121, 21);
            this.CBArco.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Arco:";
            // 
            // btnEliminarVer
            // 
            this.btnEliminarVer.Location = new System.Drawing.Point(200, 31);
            this.btnEliminarVer.Name = "btnEliminarVer";
            this.btnEliminarVer.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarVer.TabIndex = 2;
            this.btnEliminarVer.Text = "Eliminar";
            this.btnEliminarVer.UseVisualStyleBackColor = true;
            this.btnEliminarVer.Click += new System.EventHandler(this.btnEliminarVer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Vertice:";
            // 
            // CBVertice
            // 
            this.CBVertice.FormattingEnabled = true;
            this.CBVertice.Location = new System.Drawing.Point(77, 33);
            this.CBVertice.Name = "CBVertice";
            this.CBVertice.Size = new System.Drawing.Size(121, 21);
            this.CBVertice.TabIndex = 0;
            // 
            // Recorrido
            // 
            this.Recorrido.Controls.Add(this.btnAnch);
            this.Recorrido.Controls.Add(this.btnProf);
            this.Recorrido.Controls.Add(this.label5);
            this.Recorrido.Controls.Add(this.CBNodoPartida);
            this.Recorrido.Location = new System.Drawing.Point(23, 182);
            this.Recorrido.Name = "Recorrido";
            this.Recorrido.Size = new System.Drawing.Size(281, 129);
            this.Recorrido.TabIndex = 4;
            this.Recorrido.TabStop = false;
            this.Recorrido.Text = "Recorrido";
            // 
            // btnAnch
            // 
            this.btnAnch.Location = new System.Drawing.Point(146, 79);
            this.btnAnch.Name = "btnAnch";
            this.btnAnch.Size = new System.Drawing.Size(75, 23);
            this.btnAnch.TabIndex = 9;
            this.btnAnch.Text = "Anchura";
            this.btnAnch.UseVisualStyleBackColor = true;
            this.btnAnch.Click += new System.EventHandler(this.btnAnch_Click);
            // 
            // btnProf
            // 
            this.btnProf.Location = new System.Drawing.Point(53, 79);
            this.btnProf.Name = "btnProf";
            this.btnProf.Size = new System.Drawing.Size(75, 23);
            this.btnProf.TabIndex = 8;
            this.btnProf.Text = "Profundidad";
            this.btnProf.UseVisualStyleBackColor = true;
            this.btnProf.Click += new System.EventHandler(this.btnProf_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nodo de partida:";
            // 
            // CBNodoPartida
            // 
            this.CBNodoPartida.FormattingEnabled = true;
            this.CBNodoPartida.Location = new System.Drawing.Point(115, 33);
            this.CBNodoPartida.Name = "CBNodoPartida";
            this.CBNodoPartida.Size = new System.Drawing.Size(160, 21);
            this.CBNodoPartida.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBuscar);
            this.groupBox3.Controls.Add(this.btnBuscar);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(23, 317);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(281, 87);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(59, 35);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(125, 20);
            this.txtBuscar.TabIndex = 9;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(190, 32);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Vertice:";
            // 
            // btnDistancia
            // 
            this.btnDistancia.Location = new System.Drawing.Point(264, 22);
            this.btnDistancia.Name = "btnDistancia";
            this.btnDistancia.Size = new System.Drawing.Size(83, 36);
            this.btnDistancia.TabIndex = 9;
            this.btnDistancia.Text = "Distancia";
            this.btnDistancia.UseVisualStyleBackColor = true;
            this.btnDistancia.Click += new System.EventHandler(this.btnDistancia_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRecorrido);
            this.groupBox2.Location = new System.Drawing.Point(473, 456);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 43);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recorrido";
            // 
            // lblRecorrido
            // 
            this.lblRecorrido.AutoSize = true;
            this.lblRecorrido.Location = new System.Drawing.Point(22, 20);
            this.lblRecorrido.Name = "lblRecorrido";
            this.lblRecorrido.Size = new System.Drawing.Size(0, 13);
            this.lblRecorrido.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CBNodo2);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.CBNodo1);
            this.groupBox4.Controls.Add(this.btnDistancia);
            this.groupBox4.Location = new System.Drawing.Point(23, 410);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(365, 79);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Costo de ruta";
            // 
            // CBNodo2
            // 
            this.CBNodo2.FormattingEnabled = true;
            this.CBNodo2.Location = new System.Drawing.Point(77, 46);
            this.CBNodo2.Name = "CBNodo2";
            this.CBNodo2.Size = new System.Drawing.Size(121, 21);
            this.CBNodo2.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nodo 2:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Nodo 1:";
            // 
            // CBNodo1
            // 
            this.CBNodo1.FormattingEnabled = true;
            this.CBNodo1.Location = new System.Drawing.Point(77, 19);
            this.CBNodo1.Name = "CBNodo1";
            this.CBNodo1.Size = new System.Drawing.Size(121, 21);
            this.CBNodo1.TabIndex = 10;
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 511);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Recorrido);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblRespuesta);
            this.Controls.Add(this.Pizarra);
            this.Controls.Add(this.label1);
            this.Name = "Simulador";
            this.Text = "Simulador de grafos";
            this.CMSCrearVertice.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Recorrido.ResumeLayout(false);
            this.Recorrido.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Pizarra;
        private System.Windows.Forms.ContextMenuStrip CMSCrearVertice;
        private System.Windows.Forms.ToolStripMenuItem nuevoVérticeToolStripMenuItem;
        private System.Windows.Forms.Label lblRespuesta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox Recorrido;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEliminarArc;
        private System.Windows.Forms.ComboBox CBArco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEliminarVer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBVertice;
        private System.Windows.Forms.Button btnAnch;
        private System.Windows.Forms.Button btnProf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBNodoPartida;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDistancia;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblRecorrido;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox CBNodo2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CBNodo1;
    }
}

