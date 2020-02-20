using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Screen_Calibration.Properties;

namespace Screen_Calibration
{
    public partial class Ventana_Principal : Form
    {
        public Ventana_Principal()
        {
            InitializeComponent();
        }

        internal readonly string Texto_Título = "Screen Calibration by Jupisoft for " + Program.Texto_Usuario;
        internal bool Variable_Excepción = false;
        internal bool Variable_Excepción_Imagen = false;
        internal int Variable_Excepción_Total = 0;
        internal bool Variable_Memoria = false;
        internal static Stopwatch FPS_Cronómetro = Stopwatch.StartNew();
        internal long FPS_Segundo_Anterior = 0L;
        internal long FPS_Temporal = 0L;
        internal long FPS_Real = 0L;
        /// <summary>
        /// List used to see the actual time spacing between the FPS. It can only store a full second before it resets itself.
        /// </summary>
        internal List<int> Lista_FPS_Milisegundos = new List<int>();
        /// <summary>
        /// Variable that if it's true will always show the main window on top of others.
        /// </summary>
        internal static bool Variable_Siempre_Visible = true;

        private void Ventana_Principal_Load(object sender, EventArgs e)
        {
            try
            {
                if (Program.Icono_Jupisoft == null) Program.Icono_Jupisoft = this.Icon.Clone() as Icon;
                this.Text = Texto_Título;
                Menú_Contextual_Acerca.Text = "About " + Program.Texto_Programa + " " + Program.Texto_Versión + "...";
                this.WindowState = FormWindowState.Maximized;
                Cursor.Hide();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Principal_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
                //Establecer_Imagen_Calibración(Generar_Imagen_Calibración(Picture.ClientSize));
                // Add this here so the text is always shown at the start.
                this.SizeChanged += Ventana_Principal_SizeChanged;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Cursor.Show();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Principal_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState != FormWindowState.Maximized) this.WindowState = FormWindowState.Maximized;
                else Establecer_Imagen_Calibración(Generar_Imagen_Calibración(Picture.ClientSize));
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Principal_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!e.Alt && !e.Control && !e.Shift)
                {
                    if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        this.Close();
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Principal_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    Menú_Contextual_Negativo.PerformClick();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                Cursor.Show();
                Menú_Contextual_Depurador_Excepciones.Text = "Exception debugger - [" + Program.Traducir_Número(Variable_Excepción_Total) + (Variable_Excepción_Total != 1 ? " exceptions" : " exception") + "]...";
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            try
            {
                Cursor.Hide();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Donar_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=KSMZ3XNG2R9P6", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Visor_Ayuda_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Show();
                MessageBox.Show(this, "The help file is not available yet... sorry.", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Question);
                Cursor.Hide();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Acerca_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Show();
                Ventana_Acerca Ventana = new Ventana_Acerca();
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Cursor.Hide();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Depurador_Excepciones_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Show();
                Variable_Excepción = false;
                Variable_Excepción_Imagen = false;
                Variable_Excepción_Total = 0;
                Ventana_Depurador_Excepciones Ventana = new Ventana_Depurador_Excepciones();
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Cursor.Hide();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Negativo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Establecer_Imagen_Calibración(Generar_Imagen_Calibración(Picture.ClientSize));
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Voltear_Horizontalmente_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Establecer_Imagen_Calibración(Generar_Imagen_Calibración(Picture.ClientSize));
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Voltear_Verticalmente_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Establecer_Imagen_Calibración(Generar_Imagen_Calibración(Picture.ClientSize));
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Rotar_90_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Establecer_Imagen_Calibración(Generar_Imagen_Calibración(Picture.ClientSize));
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Dibujar_Degradados_Click(object sender, EventArgs e)
        {
            try
            {
                Menú_Contextual_Dibujar_Tramas.Checked = false;
                Menú_Contextual_Dibujar_Degradados.Checked = true;
                Menú_Contextual_Dibujar_Polígonos.Checked = false;
                Menú_Contextual_Dibujar_.Checked = false;
                Establecer_Imagen_Calibración(Generar_Imagen_Calibración(Picture.ClientSize));
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Dibujar_Tramas_Click(object sender, EventArgs e)
        {
            try
            {
                Menú_Contextual_Dibujar_Tramas.Checked = true;
                Menú_Contextual_Dibujar_Degradados.Checked = false;
                Menú_Contextual_Dibujar_Polígonos.Checked = false;
                Menú_Contextual_Dibujar_.Checked = false;
                Establecer_Imagen_Calibración(Generar_Imagen_Calibración(Picture.ClientSize));
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Dibujar_Polígonos_Click(object sender, EventArgs e)
        {
            try
            {
                Menú_Contextual_Dibujar_Tramas.Checked = false;
                Menú_Contextual_Dibujar_Degradados.Checked = false;
                Menú_Contextual_Dibujar_Polígonos.Checked = true;
                Menú_Contextual_Dibujar_.Checked = false;
                Establecer_Imagen_Calibración(Generar_Imagen_Calibración(Picture.ClientSize));
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Dibujar__Click(object sender, EventArgs e)
        {
            try
            {
                Menú_Contextual_Dibujar_Tramas.Checked = false;
                Menú_Contextual_Dibujar_Degradados.Checked = false;
                Menú_Contextual_Dibujar_Polígonos.Checked = false;
                Menú_Contextual_Dibujar_.Checked = true;
                Establecer_Imagen_Calibración(Generar_Imagen_Calibración(Picture.ClientSize));
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Copiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Picture.Image != null)
                {
                    Clipboard.SetImage(Picture.Image);
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        /// <summary>
        /// Since it seems that by default .NET draws square rectangles with some differences on it's 4 sides,
        /// specially on the upper left corner. This function copies just the bottom right corner on the rest
        /// of sides to achieve some more symmetry.
        /// </summary>
        /// <param name="Imagen_Original">The original image which bottom right corner should be repeated on all of it's sides.</param>
        /// <returns>Returns a new image with at least full symmetry on all the diagonal corners. Returns null on any error.</returns>
        internal Bitmap Obtener_Imagen_Simetría_Cuádruple(Bitmap Imagen_Original)
        {
            try
            {
                if (Imagen_Original != null)
                {
                    int Ancho = Imagen_Original.Width;
                    int Alto = Imagen_Original.Height;
                    Bitmap Imagen = new Bitmap(Ancho, Alto, !Image.IsAlphaPixelFormat(Imagen_Original.PixelFormat) ? PixelFormat.Format24bppRgb : PixelFormat.Format32bppArgb);
                    Graphics Pintar = Graphics.FromImage(Imagen);
                    Pintar.CompositingMode = CompositingMode.SourceCopy;
                    Pintar.CompositingQuality = CompositingQuality.HighQuality;
                    Pintar.InterpolationMode = InterpolationMode.NearestNeighbor;
                    Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    Pintar.SmoothingMode = SmoothingMode.None;
                    Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;

                    int Ancho_2 = Ancho / 2;
                    int Alto_2 = Alto / 2;
                    if (Ancho % 2 != 0 && Ancho_2 < Ancho) Ancho_2++;
                    if (Alto % 2 != 0 && Alto_2 < Alto) Alto_2++;
                    Bitmap Imagen_Esquina = new Bitmap(Ancho_2, Alto_2, Imagen.PixelFormat);
                    Graphics Pintar_Esquina = Graphics.FromImage(Imagen_Esquina);
                    Pintar_Esquina.CompositingMode = CompositingMode.SourceCopy;
                    Pintar_Esquina.CompositingQuality = CompositingQuality.HighQuality;
                    Pintar_Esquina.InterpolationMode = InterpolationMode.NearestNeighbor;
                    Pintar_Esquina.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    Pintar_Esquina.SmoothingMode = SmoothingMode.None;
                    Pintar_Esquina.TextRenderingHint = TextRenderingHint.AntiAlias;
                    Pintar_Esquina.DrawImage(Imagen_Original, new Rectangle(0, 0, Ancho_2, Alto_2), new Rectangle(Ancho - Ancho_2, Alto - Alto_2, Ancho_2, Alto_2), GraphicsUnit.Pixel);
                    Pintar_Esquina.Dispose();
                    Pintar_Esquina = null;

                    Pintar.DrawImage(Imagen_Esquina, new Rectangle(Ancho - Ancho_2, Alto - Alto_2, Ancho_2, Alto_2), new Rectangle(0, 0, Ancho_2, Alto_2), GraphicsUnit.Pixel);

                    Imagen_Esquina.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    Pintar.DrawImage(Imagen_Esquina, new Rectangle(0, Alto - Alto_2, Ancho_2, Alto_2), new Rectangle(0, 0, Ancho_2, Alto_2), GraphicsUnit.Pixel);

                    Imagen_Esquina.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    Pintar.DrawImage(Imagen_Esquina, new Rectangle(0, 0, Ancho_2, Alto_2), new Rectangle(0, 0, Ancho_2, Alto_2), GraphicsUnit.Pixel);

                    Imagen_Esquina.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    Pintar.DrawImage(Imagen_Esquina, new Rectangle(Ancho - Ancho_2, 0, Ancho_2, Alto_2), new Rectangle(0, 0, Ancho_2, Alto_2), GraphicsUnit.Pixel);

                    Imagen_Esquina.Dispose();
                    Imagen_Esquina = null;

                    Pintar.Dispose();
                    Pintar = null;
                    return Imagen;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            return null;
        }

        internal Bitmap Generar_Imagen_Calibración(Size Dimensiones)
        {
            try
            {
                if (Dimensiones.Width > 0 && Dimensiones.Height > 0)
                {
                    if (Menú_Contextual_Rotar_90.Checked) // Swap the dimensions.
                    {
                        Dimensiones = new Size(Dimensiones.Height, Dimensiones.Width);
                    }
                    int Ancho = Dimensiones.Width;
                    int Alto = Dimensiones.Height;
                    Bitmap Imagen = new Bitmap(Dimensiones.Width, Dimensiones.Height, PixelFormat.Format24bppRgb);
                    Graphics Pintar = Graphics.FromImage(Imagen);
                    Pintar.CompositingMode = CompositingMode.SourceOver;
                    Pintar.CompositingQuality = CompositingQuality.HighQuality;
                    Pintar.InterpolationMode = InterpolationMode.NearestNeighbor;
                    Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    Pintar.SmoothingMode = SmoothingMode.None;
                    Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;

                    if (Menú_Contextual_Dibujar_Degradados.Checked)
                    {
                        Color[] Matriz_Paleta_16 = null;
                        try
                        {
                            Bitmap Imagen_Paleta_16 = new Bitmap(1, 1, PixelFormat.Format4bppIndexed);
                            Matriz_Paleta_16 = new Color[Imagen_Paleta_16.Palette.Entries.Length];
                            Imagen_Paleta_16.Palette.Entries.CopyTo(Matriz_Paleta_16, 0);
                            Imagen_Paleta_16.Dispose();
                            Imagen_Paleta_16 = null;
                        }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; Matriz_Paleta_16 = null; }

                        Color[] Matriz_Paleta_256 = null;
                        try
                        {
                            Bitmap Imagen_Paleta_256 = new Bitmap(1, 1, PixelFormat.Format8bppIndexed);
                            Matriz_Paleta_256 = new Color[Imagen_Paleta_256.Palette.Entries.Length];
                            Imagen_Paleta_256.Palette.Entries.CopyTo(Matriz_Paleta_256, 0);
                            Imagen_Paleta_256.Dispose();
                            Imagen_Paleta_256 = null;
                        }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; Matriz_Paleta_256 = null; }

                        int Ancho_1 = Math.Max(Ancho - 1, 1);
                        int Alto_16 = Math.Max(Alto / 16, 1);
                        for (int Índice_X = 0; Índice_X < Ancho; Índice_X++)
                        {
                            SolidBrush Pincel_Rojo = new SolidBrush(Color.FromArgb((256 * Índice_X) / Ancho, 0, 0));
                            SolidBrush Pincel_Naranja = new SolidBrush(Color.FromArgb((256 * Índice_X) / Ancho, (161 * Índice_X) / Ancho, 0));
                            SolidBrush Pincel_Amarillo = new SolidBrush(Color.FromArgb((256 * Índice_X) / Ancho, (256 * Índice_X) / Ancho, 0));
                            SolidBrush Pincel_Lima = new SolidBrush(Color.FromArgb((161 * Índice_X) / Ancho, (256 * Índice_X) / Ancho, 0));
                            SolidBrush Pincel_Verde = new SolidBrush(Color.FromArgb(0, (256 * Índice_X) / Ancho, 0));
                            SolidBrush Pincel_Turquesa = new SolidBrush(Color.FromArgb(0, (256 * Índice_X) / Ancho, (161 * Índice_X) / Ancho));
                            SolidBrush Pincel_Aguamarina = new SolidBrush(Color.FromArgb(0, (256 * Índice_X) / Ancho, (256 * Índice_X) / Ancho));
                            SolidBrush Pincel_Celeste = new SolidBrush(Color.FromArgb(0, (161 * Índice_X) / Ancho, (256 * Índice_X) / Ancho));
                            SolidBrush Pincel_Azul = new SolidBrush(Color.FromArgb(0, 0, (256 * Índice_X) / Ancho));
                            SolidBrush Pincel_Púrpura = new SolidBrush(Color.FromArgb((161 * Índice_X) / Ancho, 0, (256 * Índice_X) / Ancho));
                            SolidBrush Pincel_Fucsia = new SolidBrush(Color.FromArgb((256 * Índice_X) / Ancho, 0, (256 * Índice_X) / Ancho));
                            SolidBrush Pincel_Rosa = new SolidBrush(Color.FromArgb((256 * Índice_X) / Ancho, 0, (161 * Índice_X) / Ancho));
                            SolidBrush Pincel_Gris = new SolidBrush(Color.FromArgb((256 * Índice_X) / Ancho, (256 * Índice_X) / Ancho, (256 * Índice_X) / Ancho));
                            SolidBrush Pincel_Paleta_16 = new SolidBrush(Matriz_Paleta_16 != null ? Matriz_Paleta_16[(16 * Índice_X) / Ancho] : Color.White);
                            SolidBrush Pincel_Paleta_256 = new SolidBrush(Matriz_Paleta_256 != null ? Matriz_Paleta_256[(256 * Índice_X) / Ancho] : Color.White);
                            SolidBrush Pincel_Arco_Iris = new SolidBrush(Program.Obtener_Color_Puro_1530((1530 * Índice_X) / Ancho));

                            Pintar.FillRectangle(Pincel_Rojo, Índice_X, Alto_16 * 0, 1, Alto_16);
                            Pintar.FillRectangle(Pincel_Naranja, Índice_X, Alto_16 * 1, 1, Alto_16);
                            Pintar.FillRectangle(Pincel_Amarillo, Índice_X, Alto_16 * 2, 1, Alto_16);
                            Pintar.FillRectangle(Pincel_Lima, Índice_X, Alto_16 * 3, 1, Alto_16);
                            Pintar.FillRectangle(Pincel_Verde, Índice_X, Alto_16 * 4, 1, Alto_16);
                            Pintar.FillRectangle(Pincel_Turquesa, Índice_X, Alto_16 * 5, 1, Alto_16);
                            Pintar.FillRectangle(Pincel_Aguamarina, Índice_X, Alto_16 * 6, 1, Alto_16);
                            Pintar.FillRectangle(Pincel_Celeste, Índice_X, Alto_16 * 7, 1, Alto_16);
                            Pintar.FillRectangle(Pincel_Azul, Índice_X, Alto_16 * 8, 1, Alto_16);
                            Pintar.FillRectangle(Pincel_Púrpura, Índice_X, Alto_16 * 9, 1, Alto_16);
                            Pintar.FillRectangle(Pincel_Fucsia, Índice_X, Alto_16 * 10, 1, Alto_16);
                            Pintar.FillRectangle(Pincel_Rosa, Índice_X, Alto_16 * 11, 1, Alto_16);
                            Pintar.FillRectangle(Pincel_Gris, Índice_X, Alto_16 * 12, 1, Alto_16);
                            Pintar.FillRectangle(Pincel_Paleta_16, Índice_X, Alto_16 * 13, 1, Alto_16);
                            Pintar.FillRectangle(Pincel_Paleta_256, Índice_X, Alto_16 * 14, 1, Alto_16);
                            Pintar.FillRectangle(Pincel_Arco_Iris, Índice_X, Alto_16 * 15, 1, Alto - (Alto_16 * 15)); // Draw the full remaining height.

                            Pincel_Rojo.Dispose();
                            Pincel_Naranja.Dispose();
                            Pincel_Amarillo.Dispose();
                            Pincel_Lima.Dispose();
                            Pincel_Verde.Dispose();
                            Pincel_Turquesa.Dispose();
                            Pincel_Aguamarina.Dispose();
                            Pincel_Celeste.Dispose();
                            Pincel_Azul.Dispose();
                            Pincel_Púrpura.Dispose();
                            Pincel_Fucsia.Dispose();
                            Pincel_Rosa.Dispose();
                            Pincel_Gris.Dispose();
                            Pincel_Paleta_16.Dispose();
                            Pincel_Paleta_256.Dispose();
                            Pincel_Arco_Iris.Dispose();

                            Pincel_Rojo = null;
                            Pincel_Naranja = null;
                            Pincel_Amarillo = null;
                            Pincel_Lima = null;
                            Pincel_Verde = null;
                            Pincel_Turquesa = null;
                            Pincel_Aguamarina = null;
                            Pincel_Celeste = null;
                            Pincel_Azul = null;
                            Pincel_Púrpura = null;
                            Pincel_Fucsia = null;
                            Pincel_Rosa = null;
                            Pincel_Gris = null;
                            Pincel_Paleta_16 = null;
                            Pincel_Paleta_256 = null;
                            Pincel_Arco_Iris = null;
                        }
                        Matriz_Paleta_16 = null;
                        Matriz_Paleta_256 = null;
                    }
                    else if (Menú_Contextual_Dibujar_Tramas.Checked)
                    {
                        int Ancho_8 = Math.Max(Ancho / 8, 1);
                        int Alto_7 = Math.Max(Alto / 7, 1);
                        HatchBrush[] Matriz_Pinceles_Trama = new HatchBrush[53];
                        for (int Índice = 0; Índice < Matriz_Pinceles_Trama.Length; Índice++)
                        {
                            Matriz_Pinceles_Trama[Índice] = new HatchBrush((HatchStyle)Índice, Color.White, Color.Black);
                        }
                        for (int Índice_Y = 0, Índice = 0; Índice_Y < 7; Índice_Y++)
                        {
                            for (int Índice_X = 0; Índice_X < 8; Índice_X++, Índice++)
                            {
                                if (Índice < 53)
                                {
                                    Pintar.FillRectangle(Matriz_Pinceles_Trama[Índice], Índice_X * Ancho_8, Índice_Y * Alto_7, Ancho_8, Índice_Y < 6 ? Alto_7 : Alto - (Alto_7 * 6));
                                }
                                /*else if (Índice == 53) // Needed?
                                {
                                    Pintar.FillRectangle(Brushes.Black, Índice_X * Ancho_8, Índice_Y * Alto_7, Ancho_8, Índice_Y < 6 ? Alto_7 : Alto - (Alto_7 * 6));
                                }*/
                                else if (Índice == 54)
                                {
                                    Pintar.FillRectangle(Brushes.Gray, Índice_X * Ancho_8, Índice_Y * Alto_7, Ancho_8, Índice_Y < 6 ? Alto_7 : Alto - (Alto_7 * 6));
                                }
                                else if (Índice == 55)
                                {
                                    Pintar.FillRectangle(Brushes.White, Índice_X * Ancho_8, Índice_Y * Alto_7, Ancho_8, Índice_Y < 6 ? Alto_7 : Alto - (Alto_7 * 6));
                                }
                            }
                        }
                        for (int Índice = 0; Índice < Matriz_Pinceles_Trama.Length; Índice++)
                        {
                            Matriz_Pinceles_Trama[Índice].Dispose();
                            Matriz_Pinceles_Trama[Índice] = null;
                        }
                    }
                    else if (Menú_Contextual_Dibujar_Polígonos.Checked)
                    {
                        int Alto_8 = Math.Max(Alto / 8, 1); 
                        int Polígonos = Math.Max(Ancho / Alto_8, 1) + 1;
                        double Radio = (double)Alto_8 / 2d;

                        for (int Índice_Y = 0, Separación = 1; Índice_Y <= 8; Índice_Y++, Separación += 1)
                        {
                            //int Separación_Polígonos_2 = Separación_Polígonos * 2;
                            //int Iteraciones = Alto_8_Polígono / Separación_Polígonos_2; // Automatic number of drawings.
                            //double Índice_Radio = 0d;
                            //for (double Índice_Radio = 0d; Índice_Radio < Radio - 4d; Índice_Radio += (double)Separación)
                            for (int Índice_Radio = 0; Índice_Radio <= Alto_8 / (Separación * 2); Índice_Radio++)
                            {
                                for (int Índice_X = 0, Índice_Polígono = 3; Índice_X < Polígonos; Índice_X++, Índice_Polígono++)
                                {
                                    if (Índice_Polígono >= 3)
                                    {
                                        double Ángulo = 360d / (double)Índice_Polígono;
                                        PointF[] Matriz_Posiciones = new PointF[Índice_Polígono];
                                        for (int Índice = 0; Índice < Índice_Polígono; Índice++)
                                        {
                                            Matriz_Posiciones[Índice] = new PointF((float)(Math.Sin(((Ángulo * (double)Índice) * Math.PI) / 180d) * (Radio - (Separación * Índice_Radio))), (float)(Math.Cos(((Ángulo * (double)Índice) * Math.PI) / 180d) * (Radio - (Separación * Índice_Radio))));
                                        }
                                        Pintar.TranslateTransform((float)(((double)Alto_8 / 2d) + ((double)Alto_8 * Índice_X)), (float)((double)Alto_8 / 2d) + (Alto_8 * Índice_Y));
                                        if (Índice_Radio % 2 == 0) Pintar.RotateTransform((float)(Ángulo / 2d));
                                        //if (Índice_Polígono % 2 != 0) Pintar.RotateTransform(180f);
                                        //else Pintar.RotateTransform((float)(Ángulo / 2d));
                                        Pintar.DrawPolygon(Pens.White, Matriz_Posiciones);
                                        Pintar.ResetTransform();
                                        Matriz_Posiciones = null;
                                    }
                                }
                            }
                        }

                        /*for (int Índice_Separación = 2, Índice_Separación_2 = Índice_Separación * 2; Índice_Separación < 10; Índice_Separación++, Índice_Separación_2 = Índice_Separación * 2)
                        {
                            Bitmap Imagen_Cuadrado = new Bitmap(Alto_8, Alto_8, Imagen.PixelFormat);
                            Graphics Pintar_Cuadrado = Graphics.FromImage(Imagen_Cuadrado);
                            Pintar_Cuadrado.CompositingMode = CompositingMode.SourceOver;
                            Pintar_Cuadrado.CompositingQuality = CompositingQuality.HighQuality;
                            Pintar_Cuadrado.InterpolationMode = InterpolationMode.NearestNeighbor;
                            Pintar_Cuadrado.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            Pintar_Cuadrado.SmoothingMode = SmoothingMode.None;
                            Pintar_Cuadrado.TextRenderingHint = TextRenderingHint.AntiAlias;
                            for (int Índice_Iteración = 0; Índice_Iteración <= Índice_Separación; Índice_Iteración++)
                            {
                                Pintar_Cuadrado.DrawRectangle(Pens.White, Índice_Separación * Índice_Iteración, Índice_Separación * Índice_Iteración, Alto_8 - (Índice_Separación_2 * Índice_Iteración), Alto_8 - (Índice_Separación_2 * Índice_Iteración));
                            }
                            Pintar_Cuadrado.Dispose();
                            Pintar_Cuadrado = null;
                            // This function will avoid the default bad drawings of .NET and add real 4 sides symmetry.
                            Imagen_Cuadrado = Obtener_Imagen_Simetría_Cuádruple(Imagen_Cuadrado);
                            if (Imagen_Cuadrado != null)
                            {
                                Pintar.DrawImage(Imagen_Cuadrado, new Rectangle(Centro_X_Polígono, Alto_8 * Índice_Y, Alto_8, Alto_8), new Rectangle(0, 0, Alto_8, Alto_8), GraphicsUnit.Pixel);
                            }
                            Imagen_Cuadrado.Dispose();
                            Imagen_Cuadrado = null;
                        }*/
                    }
                    /*else if (Menú_Contextual_Dibujar_.Checked)
                    {

                    }*/
                    else
                    {
                        int Centro_X = Dimensiones.Width / 2;
                        int Centro_Y = Dimensiones.Height / 2;

                        // Add all the 53 hatch brush styles.
                        int Ancho_8_Trama = Math.Max(((Ancho - 256) / 2) / 8, 1);
                        int Alto_8_Trama = Math.Max(Alto / 8, 1);
                        HatchBrush[] Matriz_Pinceles_Trama = new HatchBrush[53];
                        for (int Índice = 0; Índice < Matriz_Pinceles_Trama.Length; Índice++)
                        {
                            Matriz_Pinceles_Trama[Índice] = new HatchBrush((HatchStyle)Índice, Color.White, Color.Black);
                        }
                        for (int Índice_Y = 0, Índice = 0; Índice_Y < 8; Índice_Y++)
                        {
                            for (int Índice_X = 0; Índice_X < 8; Índice_X++, Índice++)
                            {
                                if (Índice < 53)
                                {
                                    Pintar.FillRectangle(Matriz_Pinceles_Trama[Índice], Índice_X * Ancho_8_Trama, Índice_Y * Alto_8_Trama, Ancho_8_Trama, Alto_8_Trama);
                                }
                            }
                        }
                        for (int Índice = 0; Índice < Matriz_Pinceles_Trama.Length; Índice++)
                        {
                            Matriz_Pinceles_Trama[Índice].Dispose();
                            Matriz_Pinceles_Trama[Índice] = null;
                        }

                        // Add 7 gradients from black to a full basic color.
                        for (int Índice = 0, Centro_X_256 = Centro_X - 128, Alto_8 = Alto / 8; Índice < 256; Índice++)
                        {
                            SolidBrush Pincel_Rojo = new SolidBrush(Color.FromArgb(Índice, 0, 0));
                            SolidBrush Pincel_Verde = new SolidBrush(Color.FromArgb(0, Índice, 0));
                            SolidBrush Pincel_Azul = new SolidBrush(Color.FromArgb(0, 0, Índice));
                            SolidBrush Pincel_Cian = new SolidBrush(Color.FromArgb(0, Índice, Índice));
                            SolidBrush Pincel_Magenta = new SolidBrush(Color.FromArgb(Índice, 0, Índice));
                            SolidBrush Pincel_Amarillo = new SolidBrush(Color.FromArgb(Índice, Índice, 0));
                            SolidBrush Pincel_Gris = new SolidBrush(Color.FromArgb(Índice, Índice, Índice));

                            Pintar.FillRectangle(Pincel_Rojo, Centro_X_256 + Índice, Alto_8 * 0, 1, Alto_8);
                            Pintar.FillRectangle(Pincel_Amarillo, Centro_X_256 + Índice, Alto_8 * 1, 1, Alto_8);
                            Pintar.FillRectangle(Pincel_Verde, Centro_X_256 + Índice, Alto_8 * 2, 1, Alto_8);
                            Pintar.FillRectangle(Pincel_Cian, Centro_X_256 + Índice, Alto_8 * 3, 1, Alto_8);
                            Pintar.FillRectangle(Pincel_Azul, Centro_X_256 + Índice, Alto_8 * 4, 1, Alto_8);
                            Pintar.FillRectangle(Pincel_Magenta, Centro_X_256 + Índice, Alto_8 * 5, 1, Alto_8);
                            Pintar.FillRectangle(Pincel_Gris, Centro_X_256 + Índice, Alto_8 * 6, 1, Alto_8);

                            Pincel_Rojo.Dispose();
                            Pincel_Verde.Dispose();
                            Pincel_Azul.Dispose();
                            Pincel_Cian.Dispose();
                            Pincel_Magenta.Dispose();
                            Pincel_Amarillo.Dispose();
                            Pincel_Gris.Dispose();

                            Pincel_Rojo = null;
                            Pincel_Verde = null;
                            Pincel_Azul = null;
                            Pincel_Cian = null;
                            Pincel_Magenta = null;
                            Pincel_Amarillo = null;
                            Pincel_Gris = null;
                        }

                        // Add multiple polygons.
                        int Centro_X_Polígono = Centro_X + 128;
                        int Alto_8_Polígono = Alto / 8;
                        int Alto_8_Polígono_2 = (Alto / 8) / 2;

                        // The separation between polygons of different sizes starts at 2.
                        for (int Índice_Y = 0, Separación_Polígonos = 2; Índice_Y < 7; Índice_Y++, Separación_Polígonos++)
                        {
                            int Separación_Polígonos_2 = Separación_Polígonos * 2;
                            int Iteraciones = Alto_8_Polígono / Separación_Polígonos_2; // Automatic number of drawings.

                            Bitmap Imagen_Cuadrado = new Bitmap(Alto_8_Polígono, Alto_8_Polígono, Imagen.PixelFormat);
                            Graphics Pintar_Cuadrado = Graphics.FromImage(Imagen_Cuadrado);
                            Pintar_Cuadrado.CompositingMode = CompositingMode.SourceOver;
                            Pintar_Cuadrado.CompositingQuality = CompositingQuality.HighQuality;
                            Pintar_Cuadrado.InterpolationMode = InterpolationMode.NearestNeighbor;
                            Pintar_Cuadrado.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            Pintar_Cuadrado.SmoothingMode = SmoothingMode.None;
                            Pintar_Cuadrado.TextRenderingHint = TextRenderingHint.AntiAlias;
                            for (int Índice_Iteración = 0; Índice_Iteración <= Iteraciones; Índice_Iteración++)
                            {
                                Pintar_Cuadrado.DrawRectangle(Pens.White, Separación_Polígonos * Índice_Iteración, Separación_Polígonos * Índice_Iteración, Alto_8_Polígono - (Separación_Polígonos_2 * Índice_Iteración), Alto_8_Polígono - (Separación_Polígonos_2 * Índice_Iteración));
                            }
                            Pintar_Cuadrado.Dispose();
                            Pintar_Cuadrado = null;
                            // This function will avoid the default bad drawings of .NET and add real 4 sides symmetry.
                            Imagen_Cuadrado = Obtener_Imagen_Simetría_Cuádruple(Imagen_Cuadrado);
                            if (Imagen_Cuadrado != null)
                            {
                                Pintar.DrawImage(Imagen_Cuadrado, new Rectangle(Centro_X_Polígono, Alto_8_Polígono * Índice_Y, Alto_8_Polígono, Alto_8_Polígono), new Rectangle(0, 0, Alto_8_Polígono, Alto_8_Polígono), GraphicsUnit.Pixel);
                            }
                            Imagen_Cuadrado.Dispose();
                            Imagen_Cuadrado = null;

                            Bitmap Imagen_Círculo = new Bitmap(Alto_8_Polígono, Alto_8_Polígono, Imagen.PixelFormat);
                            Graphics Pintar_Círculo = Graphics.FromImage(Imagen_Círculo);
                            Pintar_Círculo.CompositingMode = CompositingMode.SourceOver;
                            Pintar_Círculo.CompositingQuality = CompositingQuality.HighQuality;
                            Pintar_Círculo.InterpolationMode = InterpolationMode.NearestNeighbor;
                            Pintar_Círculo.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            Pintar_Círculo.SmoothingMode = SmoothingMode.None;
                            Pintar_Círculo.TextRenderingHint = TextRenderingHint.AntiAlias;
                            for (int Índice_Iteración = 0; Índice_Iteración <= Iteraciones; Índice_Iteración++)
                            {
                                Pintar_Círculo.DrawEllipse(Pens.White, Separación_Polígonos * Índice_Iteración, Separación_Polígonos * Índice_Iteración, Alto_8_Polígono - (Separación_Polígonos_2 * Índice_Iteración), Alto_8_Polígono - (Separación_Polígonos_2 * Índice_Iteración));
                            }
                            Pintar_Círculo.Dispose();
                            Pintar_Círculo = null;
                            // This function will avoid the default bad drawings of .NET and add real 4 sides symmetry.
                            Imagen_Círculo = Obtener_Imagen_Simetría_Cuádruple(Imagen_Círculo);
                            if (Imagen_Círculo != null)
                            {
                                Pintar.DrawImage(Imagen_Círculo, new Rectangle(Centro_X_Polígono + Alto_8_Polígono, Alto_8_Polígono * Índice_Y, Alto_8_Polígono, Alto_8_Polígono), new Rectangle(0, 0, Alto_8_Polígono, Alto_8_Polígono), GraphicsUnit.Pixel);
                            }
                            Imagen_Círculo.Dispose();
                            Imagen_Círculo = null;

                            /*Pintar.TranslateTransform(Centro_X_Derecha + Alto_8_2, (Alto_8_ * 0) + Alto_8_2);

                            for (int Índice = 0; Índice < Iteraciones; Índice++)
                            {
                                Pintar.DrawEllipse(Pens.White, (-Alto_8_2 + (Índice * Separación_Polígonos)) + (Alto_8_ * 1), (-Alto_8_2 + (Índice * Separación_Polígonos)) + (Alto_8_ * Índice_X), Alto_8_ - (Índice * Separación_Polígonos_2), Alto_8_ - (Índice * Separación_Polígonos_2));
                            }
                            Pintar.ResetTransform();*/
                        }

                        // Add 2 direction rectangles.
                        int Ancho_8_Rectángulo = Math.Max(((Ancho - 256) / 2) / 8, 1);
                        int Alto_8_Rectángulo = Math.Max(Alto / 8, 1);
                    }

                    Pintar.Dispose();
                    Pintar = null;
                    return Imagen;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            return null;
        }

        internal void Establecer_Imagen_Calibración(Bitmap Imagen)
        {
            try
            {
                if (Imagen != null)
                {
                    if (Etiqueta_Información.Visible)
                    {
                        Etiqueta_Información.Enabled = false;
                        Etiqueta_Información.Visible = false;
                    }
                    if (Menú_Contextual_Negativo.Checked)
                    {
                        int Ancho = Imagen.Width;
                        int Alto = Imagen.Height;
                        BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadWrite, Imagen.PixelFormat);
                        byte[] Matriz_Bytes = new byte[Math.Abs(Bitmap_Data.Stride) * Alto];
                        Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
                        int Bytes_Aumento = Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 4 : 3;
                        int Bytes_Diferencia = Math.Abs(Bitmap_Data.Stride) - ((Ancho * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                        for (int Y = 0, Índice = 0; Y < Alto; Y++, Índice += Bytes_Diferencia)
                        {
                            for (int X = 0; X < Ancho; X++, Índice += Bytes_Aumento)
                            {
                                Matriz_Bytes[Índice + 2] = (byte)(255 - Matriz_Bytes[Índice + 2]);
                                Matriz_Bytes[Índice + 1] = (byte)(255 - Matriz_Bytes[Índice + 1]);
                                Matriz_Bytes[Índice] = (byte)(255 - Matriz_Bytes[Índice]);
                            }
                        }
                        Marshal.Copy(Matriz_Bytes, 0, Bitmap_Data.Scan0, Matriz_Bytes.Length);
                        Imagen.UnlockBits(Bitmap_Data);
                        Bitmap_Data = null;
                        Matriz_Bytes = null;
                    }
                    if (Menú_Contextual_Voltear_Horizontalmente.Checked)
                    {
                        Imagen.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    }
                    if (Menú_Contextual_Voltear_Verticalmente.Checked)
                    {
                        Imagen.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    }
                    if (Menú_Contextual_Rotar_90.Checked)
                    {
                        // Use this rotation, so the top left corner will always be the start.
                        Imagen.RotateFlip(RotateFlipType.Rotate90FlipX);
                    }
                }
                Picture.Image = Imagen;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }
    }
}
