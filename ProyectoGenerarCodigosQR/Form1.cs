using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QRCoder.PayloadGenerator;
using System.Drawing.Imaging;

namespace ProyectoGenerarCodigosQR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string contenido = txtContenido.Text;

            Url url = new Url("www.youtube.com");
            PhoneNumber telefono = new PhoneNumber(contenido);
            SMS mensaje = new SMS("+522431168997", "Hola");
            WhatsAppMessage whats = new WhatsAppMessage("+525623502593", "Subscribete ahora bro");

            WiFi wifi = new WiFi("MEGACABLE-2.4G-FCA3", "tK4eu5g5Th", WiFi.Authentication.WPA);


            QRCodeGenerator qrGenerador = new QRCodeGenerator();
            QRCodeData qrDatos = qrGenerador.CreateQrCode(contenido, QRCodeGenerator.ECCLevel.H);
            QRCode qrCodigo = new QRCode(qrDatos);

            Bitmap qrImagen = qrCodigo.GetGraphic(8, Color.Black, Color.White, 
                (Bitmap)Bitmap.FromFile(@"C:\imagenLogo\logo2.jpg"));
            pictureBox.Image = qrImagen;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "JPEG|*.jpeg";

            if(saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                string varimg = saveFileDialog1.FileName;
                Bitmap varbmp = new Bitmap(pictureBox.Image);
                varbmp.Save(varimg, ImageFormat.Jpeg);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtContenido.Text = "";
        }
    }
}
