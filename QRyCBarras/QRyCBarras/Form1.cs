using BarcodeLib;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barcode = BarcodeLib.Barcode;

namespace QRyCBarras
{
    public partial class Form1 : Form
    {
        public class OpcionCombo
        {
            public int Valor { get; set; }
            public string Texto { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("ejemplo 1");
            comboBox1.Items.Add("ejemplo 2");
            comboBox1.Items.Add("ejemplo 3");
            comboBox1.Items.Add("ejemplo 4");
        }
        



        private void button1_Click(object sender, EventArgs e)
        {

            string codigo = "";
            if (comboBox1.SelectedIndex == 0)
            {
                codigo = "(415)444498148888(8020)000787323000(3900)0000075000(96)20221224";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                codigo = "(415)444498145654(8020)000356323000(3900)0000050000(96)20221231";
            }
            QRCoder.QRCodeGenerator QR = new QRCoder.QRCodeGenerator();
            ASCIIEncoding ASSCII = new ASCIIEncoding();
            var z = QR.CreateQrCode(ASSCII.GetBytes(codigo), QRCoder.QRCodeGenerator.ECCLevel.Q);
            QRCoder.PngByteQRCode png = new QRCoder.PngByteQRCode();
            png.SetQRCodeData(z);
            var arr = png.GetGraphic(10);
            MemoryStream ms = new MemoryStream();
            ms.Write(arr, 0, arr.Length);
            Bitmap b = new Bitmap(ms);
            pictureBox2.Image = b;

            DateTime date = new DateTime();

            List<datos> listdatos = new List<datos>();
            datos dato = new datos();
            dato.Factura = "765765";
            dato.Fecha=
            dato.Concepto   ="44234";
            dato.Vigencia   ="44234";
            dato.Avaluo     =44234;
            dato.Tarifa     =44234;
            dato.FechaDesde ="44234";
            dato.Valor      =44234;
            dato.Mora       =44234;
            dato.Interes    =44234;
            dato.Descuento  =44234;
            dato.Total      =44234;

            dato.Nombre = "56543";
            dato.Cedula              ="56543";
            dato.Direccion           ="56543";
            dato.FichaCatastral      ="56543";
            dato.Estrato             ="56543";
            dato.Categoria           ="56543";
            dato.Propietarios        ="56543";
            dato.DebeDesde           ="56543";
            dato.Hectareas           ="56543";
            dato.MetrosCuadrados     ="56543";
            dato.AreaConstruida      ="56543";
            dato.FechaVencimiento    =date;
            dato.TotalAPagarPeriodo  =56543;
            dato.TotalAPagarVigencia =56543;
            dato.Entidad             ="56543";
            dato.Fecha               ="7657";
            dato.C_TotPer            =56543;
            dato.C_TotVig            =56543; 
            dato.C_VigAnt            ="56543";
            dato.C_VigPer            ="56543";
            dato.C_VigAct            ="56543";
            dato.C_Mensaje           ="56543";
            dato.C_Tipo              ="56543";
            dato.Pagada              ="56543";
            dato.Postal              ="56543";

            listdatos.Add(dato);
            

            HtmlToPdf pdf = new HtmlToPdf();


            SelectPdf.PdfDocument document = pdf.ConvertHtmlString(LlenarPDF(listdatos));
          

            //SaveFileDialog savefile = new SaveFileDialog();
            //savefile.FileName = string.Format("{0}.pdf","PDF");
            //if (savefile.ShowDialog() == DialogResult.OK)
            //{

            //    document.Save(savefile.FileName);

            //}



        }
        public imagendata Coder()
        {
            string codigobarras = "";
            if (comboBox1.SelectedIndex == 0)
            {
                codigobarras = "(415)444498148888(8020)000787323000(3900)0000075000(96)20221224";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                codigobarras = "(415)444498145654(8020)000356323000(3900)0000050000(96)20221231";
            }






            imagendata dataimagen = new imagendata();
            System.Drawing.Image imagenCodigo;

            BarcodeLib.TYPE tipoCodigo = (BarcodeLib.TYPE)31;

            Barcode codigo = new Barcode();
            codigo.IncludeLabel = true;
            codigo.LabelPosition = LabelPositions.BOTTOMCENTER;

            imagenCodigo = codigo.Encode(tipoCodigo, codigobarras, Color.Black, Color.White, 800, 150);

            Bitmap imagenNueva = new Bitmap(800, 400);
            Graphics dibujar = Graphics.FromImage(imagenNueva);

            dibujar.DrawImage(imagenCodigo, new Point(0, 0));
            pictureBox1.BackgroundImage = imagenNueva;
            
            imagenNueva.Save("C:/Users/jgarcia/Desktop/imagen.png");
            dataimagen.ruta="C:/Users/jgarcia/Desktop/imagen.png";
            dataimagen.imagen = imagenNueva;
            return dataimagen;
        }
        private string LlenarPDF(List<datos> ListData)
        {
            NumberFormatInfo nfi = new CultureInfo("es-ES", false).NumberFormat;

            datos datos = ListData[0];
            string body = string.Empty;
            FileStream Archivo = new FileStream("PredialInirida.html", FileMode.Open, FileAccess.Read);
            using (StreamReader reader = new StreamReader(Archivo))
            {
                body = reader.ReadToEnd();
            }
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            StringBuilder sb3 = new StringBuilder();
            StringBuilder sb4 = new StringBuilder();
            StringBuilder sb5 = new StringBuilder();
            StringBuilder sb6 = new StringBuilder();
            StringBuilder sb7 = new StringBuilder();
            StringBuilder sb8 = new StringBuilder();
            StringBuilder sb9 = new StringBuilder();
            decimal TotalFactura = 0;
            string str7 = "";
            body = body.Replace("{Factura}", datos.Factura);
            body = body.Replace("{Nombre}", datos.Nombre);
            body = body.Replace("{Cedula}", datos.Cedula);
            body = body.Replace("{Direccion}", datos.Direccion);
            body = body.Replace("{FichaCatastral}", datos.FichaCatastral);
            body = body.Replace("{Estrato}", datos.Estrato);
            body = body.Replace("{Categorias}", datos.Categoria);
            body = body.Replace("{Propietarios}", datos.Propietarios);
            body = body.Replace("{Hectareas}", datos.Hectareas);
            body = body.Replace("{MetrosCuadrados}", datos.MetrosCuadrados);
            body = body.Replace("{AreaConstruida}", datos.AreaConstruida.ToString());
            body = body.Replace("{FechaVencimiento}", Convert.ToDateTime(datos.FechaVencimiento).ToShortDateString());
            body = body.Replace("{FechaDesde}", datos.FechaDesde);



            foreach (var item in ListData)
            {
                if (item.Concepto != null && item.Concepto != string.Empty)
                {
                    sb.Append(string.Concat("<tr><td colspan='2' align='left' style='padding: 2px 5px; border-left: 0px solid black; border-bottom: 1px solid black;'><span style='font-size: 12px;'>", item.Concepto, "</span></td></tr>"));
                }
                else
                {
                    sb.Append(string.Concat("<tr><td colspan='2' align='left' style='padding: 2px 5px; border-left: 0px solid black; border-bottom: 1px solid black;'><span style='font-size: 14px; margin: 32px;'>&nbsp;</span></td></tr>"));
                }
                str7 = string.Concat(str7, "<tr>");
                str7 = string.Concat(str7, "<td> <b style='border - right: 3px solid #8e8e8e; font-family:Verdana; font-size:13px;'>", item.Concepto, "</b></td>");
                str7 = string.Concat(str7, "<td style='border - right: 3px solid #8e8e8e; font-family:Verdana; font-size:13px;'>", item.Vigencia, "</td>");
                str7 = string.Concat(str7, "<td style='border - right: 3px solid #8e8e8e; font-family:Verdana; font-size:13px;'>", string.Concat("$ ", item.Avaluo.ToString("N", nfi)), "</td>");
                str7 = string.Concat(str7, "<td style='border - right: 3px solid #8e8e8e; font-family:Verdana; font-size:13px;'>", item.Tarifa, "</td>");
                str7 = string.Concat(str7, "<td style='border - right: 3px solid #8e8e8e; font-family:Verdana; font-size:13px;'>", item.FechaDesde, "</td>");
                str7 = string.Concat(str7, "<td style='border - right: 3px solid #8e8e8e; font-family:Verdana; font-size:13px;'>", string.Concat("$ ", item.Valor.ToString("N", nfi)), "</td>");
                str7 = string.Concat(str7, "<td style='border - right: 3px solid #8e8e8e; font-family:Verdana; font-size:13px;'>", string.Concat("$ ", item.Mora.ToString("N", nfi)), "</td>");
                str7 = string.Concat(str7, "<td style='border - right: 3px solid #8e8e8e; font-family:Verdana; font-size:13px;'>", string.Concat("$ ", item.Interes.ToString("N", nfi)), "</td>");
                str7 = string.Concat(str7, "<td style='border - right: 3px solid #8e8e8e; font-family:Verdana; font-size:13px;'>", string.Concat("$ ", item.Descuento.ToString("N", nfi)), "</td>");
                str7 = string.Concat(str7, "<td style='border - right: 3px solid #8e8e8e; font-family:Verdana; font-size:13px;'>", string.Concat("$ ", item.Total.ToString("N", nfi)), "</td>");
                str7 = string.Concat(str7, "</tr>");

                TotalFactura += item.Total;
            }

            body = body.Replace("{Concepto}", sb.ToString());
            body = body.Replace("{Vigencia}", sb1.ToString());
            body = body.Replace("{Avaluo}", sb2.ToString());
            body = body.Replace("{Tarifa}", sb3.ToString());
            body = body.Replace("{Desde}", sb4.ToString());
            body = body.Replace("{Valor}", sb5.ToString());
            body = body.Replace("{Mora}", sb6.ToString());
            body = body.Replace("{Intereses}", sb7.ToString());
            body = body.Replace("{Descuento}", sb8.ToString());
            body = body.Replace("{Total}", sb9.ToString());
            body = body.Replace("{C_VigAnt}", datos.C_VigAnt);
            body = body.Replace("{C_VigPer}", datos.C_VigPer);
            body = body.Replace("{C_VigAct}", datos.C_VigAct);
            body = body.Replace("{TotalAPagarPeriodo}", datos.TotalAPagarPeriodo.ToString("N", nfi));
            body = body.Replace("{TotalAPagarVigencia}", datos.TotalAPagarVigencia.ToString("N", nfi));
            body = body.Replace("{FechaActual}", DateTime.Now.ToString("dd/MM/yyyy"));
            body = body.Replace("{InsertTable}", str7);

            //var FechaVen = Convert.ToDateTime(datos.FechaVencimiento).ToShortDateString().Replace("/", "");
            string[] FechaVen = Convert.ToDateTime(datos.FechaVencimiento).ToShortDateString().Split('/');
            body = body.Replace("{CodePeriodo}",Coder().ruta);
            

            return body;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
