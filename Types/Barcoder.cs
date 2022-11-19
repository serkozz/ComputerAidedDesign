using PdfSharp;
using BarcodeLib;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

public class Barcoder 
{
    public Barcode Barcode { get; private set; } = new Barcode();
    public string InFile { get; private set; } = string.Empty;
    public string RegNum { get; private set; } = string.Empty;
    public string BarcodeText { get; private set; } = DateTime.Now.ToString("dd:MM:yyyy");
    public string NumStruct { get; private set; } = string.Empty;
    public Image BarcodeImage { get; private set; }
    public int XPosition { get; private set; } = 0;
    public int YPosition { get; private set; } = 0;
    public int BarcodeWidth { get; private set; } = 100;
    public int BarcodeHeight { get; private set; } = 100;

    private PictureBox BarcodePictureBox;

    public Barcoder(string inFile, string regNum, PictureBox barcodePictureBox)
    {
        InFile = inFile;
        RegNum = regNum;
        BarcodePictureBox = barcodePictureBox;
        BarcodeImage = BarcodePictureBox.Image;
    }

    public void BarcodeDocument()
    {
        using (MemoryStream memoryStream = new())
        {
            /// Без этой строки не поддерживается кодировка Windows 1252
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            BarcodeImage = Barcode.Encode(TYPE.CODE128C, RegNum, Color.Black, Color.White, BarcodePictureBox.Width, BarcodePictureBox.Height);
            BarcodePictureBox.Image = BarcodeImage;

            BarcodeImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            XImage image = XImage.FromStream(memoryStream);
            PdfDocument document = PdfReader.Open(InFile, PdfDocumentOpenMode.Modify);
            PdfPage page = document.Pages[0];
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont xFont = new XFont("Calibri", 8, XFontStyle.Regular);

            XPoint barcodePoint = new XPoint(300, 5);

            gfx.DrawImage(image, barcodePoint);

            gfx.DrawString("#" + RegNum + " " + BarcodeText, xFont, XBrushes.Black, barcodePoint.X, barcodePoint.Y + 34);
            document.Save(InFile);
        }
    }
}