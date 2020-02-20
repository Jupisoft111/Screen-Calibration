namespace Screen_Calibration
{
    partial class Ventana_Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventana_Principal));
            this.Menú_Contextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menú_Contextual_Donar = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Separador_1 = new System.Windows.Forms.ToolStripSeparator();
            this.Menú_Contextual_Visor_Ayuda = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Acerca = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Depurador_Excepciones = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Separador_2 = new System.Windows.Forms.ToolStripSeparator();
            this.Menú_Contextual_Negativo = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Voltear_Horizontalmente = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Voltear_Verticalmente = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Rotar_90 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Separador_3 = new System.Windows.Forms.ToolStripSeparator();
            this.Menú_Contextual_Dibujar_Degradados = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Dibujar_Tramas = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Dibujar_Polígonos = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Dibujar_ = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Separador_4 = new System.Windows.Forms.ToolStripSeparator();
            this.Menú_Contextual_Copiar = new System.Windows.Forms.ToolStripMenuItem();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.Etiqueta_Información = new System.Windows.Forms.Label();
            this.Menú_Contextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Menú_Contextual
            // 
            this.Menú_Contextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menú_Contextual_Donar,
            this.Menú_Contextual_Separador_1,
            this.Menú_Contextual_Visor_Ayuda,
            this.Menú_Contextual_Acerca,
            this.Menú_Contextual_Depurador_Excepciones,
            this.Menú_Contextual_Separador_2,
            this.Menú_Contextual_Negativo,
            this.Menú_Contextual_Voltear_Horizontalmente,
            this.Menú_Contextual_Voltear_Verticalmente,
            this.Menú_Contextual_Rotar_90,
            this.Menú_Contextual_Separador_3,
            this.Menú_Contextual_Dibujar_Degradados,
            this.Menú_Contextual_Dibujar_Tramas,
            this.Menú_Contextual_Dibujar_Polígonos,
            this.Menú_Contextual_Dibujar_,
            this.Menú_Contextual_Separador_4,
            this.Menú_Contextual_Copiar});
            this.Menú_Contextual.Name = "Menú_Contextual";
            this.Menú_Contextual.Size = new System.Drawing.Size(305, 314);
            this.Menú_Contextual.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.Menú_Contextual_Closing);
            this.Menú_Contextual.Opening += new System.ComponentModel.CancelEventHandler(this.Menú_Contextual_Opening);
            // 
            // Menú_Contextual_Donar
            // 
            this.Menú_Contextual_Donar.Image = global::Screen_Calibration.Properties.Resources.Donar;
            this.Menú_Contextual_Donar.Name = "Menú_Contextual_Donar";
            this.Menú_Contextual_Donar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.Menú_Contextual_Donar.Size = new System.Drawing.Size(304, 22);
            this.Menú_Contextual_Donar.Text = "Donate to Jupisoft (PayPal)...";
            this.Menú_Contextual_Donar.Click += new System.EventHandler(this.Menú_Contextual_Donar_Click);
            // 
            // Menú_Contextual_Separador_1
            // 
            this.Menú_Contextual_Separador_1.Name = "Menú_Contextual_Separador_1";
            this.Menú_Contextual_Separador_1.Size = new System.Drawing.Size(301, 6);
            // 
            // Menú_Contextual_Visor_Ayuda
            // 
            this.Menú_Contextual_Visor_Ayuda.Image = global::Screen_Calibration.Properties.Resources.Ayuda;
            this.Menú_Contextual_Visor_Ayuda.Name = "Menú_Contextual_Visor_Ayuda";
            this.Menú_Contextual_Visor_Ayuda.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.Menú_Contextual_Visor_Ayuda.Size = new System.Drawing.Size(304, 22);
            this.Menú_Contextual_Visor_Ayuda.Text = "Help viewer...";
            this.Menú_Contextual_Visor_Ayuda.Click += new System.EventHandler(this.Menú_Contextual_Visor_Ayuda_Click);
            // 
            // Menú_Contextual_Acerca
            // 
            this.Menú_Contextual_Acerca.Image = global::Screen_Calibration.Properties.Resources.Jupisoft_16;
            this.Menú_Contextual_Acerca.Name = "Menú_Contextual_Acerca";
            this.Menú_Contextual_Acerca.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.Menú_Contextual_Acerca.Size = new System.Drawing.Size(304, 22);
            this.Menú_Contextual_Acerca.Text = "About...";
            this.Menú_Contextual_Acerca.Click += new System.EventHandler(this.Menú_Contextual_Acerca_Click);
            // 
            // Menú_Contextual_Depurador_Excepciones
            // 
            this.Menú_Contextual_Depurador_Excepciones.Image = global::Screen_Calibration.Properties.Resources.Excepción;
            this.Menú_Contextual_Depurador_Excepciones.Name = "Menú_Contextual_Depurador_Excepciones";
            this.Menú_Contextual_Depurador_Excepciones.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.Menú_Contextual_Depurador_Excepciones.Size = new System.Drawing.Size(304, 22);
            this.Menú_Contextual_Depurador_Excepciones.Text = "Exception debugger...";
            this.Menú_Contextual_Depurador_Excepciones.Click += new System.EventHandler(this.Menú_Contextual_Depurador_Excepciones_Click);
            // 
            // Menú_Contextual_Separador_2
            // 
            this.Menú_Contextual_Separador_2.Name = "Menú_Contextual_Separador_2";
            this.Menú_Contextual_Separador_2.Size = new System.Drawing.Size(301, 6);
            // 
            // Menú_Contextual_Negativo
            // 
            this.Menú_Contextual_Negativo.CheckOnClick = true;
            this.Menú_Contextual_Negativo.Name = "Menú_Contextual_Negativo";
            this.Menú_Contextual_Negativo.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.Menú_Contextual_Negativo.Size = new System.Drawing.Size(304, 22);
            this.Menú_Contextual_Negativo.Text = "Invert colors (negative)";
            this.Menú_Contextual_Negativo.CheckedChanged += new System.EventHandler(this.Menú_Contextual_Negativo_CheckedChanged);
            // 
            // Menú_Contextual_Voltear_Horizontalmente
            // 
            this.Menú_Contextual_Voltear_Horizontalmente.CheckOnClick = true;
            this.Menú_Contextual_Voltear_Horizontalmente.Name = "Menú_Contextual_Voltear_Horizontalmente";
            this.Menú_Contextual_Voltear_Horizontalmente.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.Menú_Contextual_Voltear_Horizontalmente.Size = new System.Drawing.Size(304, 22);
            this.Menú_Contextual_Voltear_Horizontalmente.Text = "Flip horizontally (X)";
            this.Menú_Contextual_Voltear_Horizontalmente.CheckedChanged += new System.EventHandler(this.Menú_Contextual_Voltear_Horizontalmente_CheckedChanged);
            // 
            // Menú_Contextual_Voltear_Verticalmente
            // 
            this.Menú_Contextual_Voltear_Verticalmente.CheckOnClick = true;
            this.Menú_Contextual_Voltear_Verticalmente.Name = "Menú_Contextual_Voltear_Verticalmente";
            this.Menú_Contextual_Voltear_Verticalmente.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.Menú_Contextual_Voltear_Verticalmente.Size = new System.Drawing.Size(304, 22);
            this.Menú_Contextual_Voltear_Verticalmente.Text = "Flip Vertically (Y)";
            this.Menú_Contextual_Voltear_Verticalmente.CheckedChanged += new System.EventHandler(this.Menú_Contextual_Voltear_Verticalmente_CheckedChanged);
            // 
            // Menú_Contextual_Rotar_90
            // 
            this.Menú_Contextual_Rotar_90.CheckOnClick = true;
            this.Menú_Contextual_Rotar_90.Name = "Menú_Contextual_Rotar_90";
            this.Menú_Contextual_Rotar_90.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.Menú_Contextual_Rotar_90.Size = new System.Drawing.Size(304, 22);
            this.Menú_Contextual_Rotar_90.Text = "Rotate 90 degrees (swap dimensions)";
            this.Menú_Contextual_Rotar_90.CheckedChanged += new System.EventHandler(this.Menú_Contextual_Rotar_90_CheckedChanged);
            // 
            // Menú_Contextual_Separador_3
            // 
            this.Menú_Contextual_Separador_3.Name = "Menú_Contextual_Separador_3";
            this.Menú_Contextual_Separador_3.Size = new System.Drawing.Size(301, 6);
            // 
            // Menú_Contextual_Dibujar_Degradados
            // 
            this.Menú_Contextual_Dibujar_Degradados.Name = "Menú_Contextual_Dibujar_Degradados";
            this.Menú_Contextual_Dibujar_Degradados.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.Menú_Contextual_Dibujar_Degradados.Size = new System.Drawing.Size(304, 22);
            this.Menú_Contextual_Dibujar_Degradados.Text = "Draw gradient styles (adjust colors)";
            this.Menú_Contextual_Dibujar_Degradados.Click += new System.EventHandler(this.Menú_Contextual_Dibujar_Degradados_Click);
            // 
            // Menú_Contextual_Dibujar_Tramas
            // 
            this.Menú_Contextual_Dibujar_Tramas.Name = "Menú_Contextual_Dibujar_Tramas";
            this.Menú_Contextual_Dibujar_Tramas.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.Menú_Contextual_Dibujar_Tramas.Size = new System.Drawing.Size(304, 22);
            this.Menú_Contextual_Dibujar_Tramas.Text = "Draw hatch styles (adjust phase)";
            this.Menú_Contextual_Dibujar_Tramas.Click += new System.EventHandler(this.Menú_Contextual_Dibujar_Tramas_Click);
            // 
            // Menú_Contextual_Dibujar_Polígonos
            // 
            this.Menú_Contextual_Dibujar_Polígonos.Name = "Menú_Contextual_Dibujar_Polígonos";
            this.Menú_Contextual_Dibujar_Polígonos.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.Menú_Contextual_Dibujar_Polígonos.Size = new System.Drawing.Size(304, 22);
            this.Menú_Contextual_Dibujar_Polígonos.Text = "Draw polygon styles (adjust resolution)";
            this.Menú_Contextual_Dibujar_Polígonos.Click += new System.EventHandler(this.Menú_Contextual_Dibujar_Polígonos_Click);
            // 
            // Menú_Contextual_Dibujar_
            // 
            this.Menú_Contextual_Dibujar_.Name = "Menú_Contextual_Dibujar_";
            this.Menú_Contextual_Dibujar_.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.Menú_Contextual_Dibujar_.Size = new System.Drawing.Size(304, 22);
            this.Menú_Contextual_Dibujar_.Text = "Draw test styles (unfinished)";
            this.Menú_Contextual_Dibujar_.Click += new System.EventHandler(this.Menú_Contextual_Dibujar__Click);
            // 
            // Menú_Contextual_Separador_4
            // 
            this.Menú_Contextual_Separador_4.Name = "Menú_Contextual_Separador_4";
            this.Menú_Contextual_Separador_4.Size = new System.Drawing.Size(301, 6);
            // 
            // Menú_Contextual_Copiar
            // 
            this.Menú_Contextual_Copiar.Image = global::Screen_Calibration.Properties.Resources.Copiar;
            this.Menú_Contextual_Copiar.Name = "Menú_Contextual_Copiar";
            this.Menú_Contextual_Copiar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.Menú_Contextual_Copiar.Size = new System.Drawing.Size(304, 22);
            this.Menú_Contextual_Copiar.Text = "Copy the current image";
            this.Menú_Contextual_Copiar.Click += new System.EventHandler(this.Menú_Contextual_Copiar_Click);
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.Color.Black;
            this.Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Picture.InitialImage = null;
            this.Picture.Location = new System.Drawing.Point(0, 0);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(640, 360);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Picture.TabIndex = 11;
            this.Picture.TabStop = false;
            // 
            // Etiqueta_Información
            // 
            this.Etiqueta_Información.BackColor = System.Drawing.Color.Black;
            this.Etiqueta_Información.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Etiqueta_Información.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.Etiqueta_Información.ForeColor = System.Drawing.Color.White;
            this.Etiqueta_Información.Location = new System.Drawing.Point(0, 0);
            this.Etiqueta_Información.Name = "Etiqueta_Información";
            this.Etiqueta_Información.Size = new System.Drawing.Size(640, 360);
            this.Etiqueta_Información.TabIndex = 12;
            this.Etiqueta_Información.Text = resources.GetString("Etiqueta_Información.Text");
            this.Etiqueta_Información.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ventana_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.ContextMenuStrip = this.Menú_Contextual;
            this.Controls.Add(this.Etiqueta_Información);
            this.Controls.Add(this.Picture);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ventana_Principal";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen Calibration by Jupisoft";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ventana_Principal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ventana_Principal_FormClosed);
            this.Load += new System.EventHandler(this.Ventana_Principal_Load);
            this.Shown += new System.EventHandler(this.Ventana_Principal_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Principal_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ventana_Principal_MouseDown);
            this.Menú_Contextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip Menú_Contextual;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Donar;
        private System.Windows.Forms.ToolStripSeparator Menú_Contextual_Separador_1;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Visor_Ayuda;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Acerca;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Depurador_Excepciones;
        private System.Windows.Forms.ToolStripSeparator Menú_Contextual_Separador_2;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Negativo;
        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Voltear_Horizontalmente;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Voltear_Verticalmente;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Rotar_90;
        private System.Windows.Forms.ToolStripSeparator Menú_Contextual_Separador_3;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Dibujar_Tramas;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Dibujar_Degradados;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Dibujar_Polígonos;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Dibujar_;
        private System.Windows.Forms.Label Etiqueta_Información;
        private System.Windows.Forms.ToolStripSeparator Menú_Contextual_Separador_4;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Copiar;
    }
}

