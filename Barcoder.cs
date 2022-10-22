using PdfSharp;
using BarcodeLib;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

public class Barcoder 
{
    public Barcode Barcode { get; private set; } = new Barcode();
    public string InFile { get; private set; } = string.Empty;
    // public string OutFile { get; private set; } = string.Empty;
    public string RegNum { get; private set; } = string.Empty;
    public string BarcodeText { get; private set; } = DateTime.Now.ToString("dd:MM:yyyy");
    public string NumStruct { get; private set; } = string.Empty;
    public Image? BarcodeImage { get; private set; }
    public int XPosition { get; private set; } = 0;
    public int YPosition { get; private set; } = 0;
    public int BarcodeWidth { get; private set; } = 100;
    public int BarcodeHeight { get; private set; } = 100;
    private PictureBox BarcodePictureBox;
    private MemoryStream memoryStream = new MemoryStream();

    public Barcoder(string inFile, string regNum, PictureBox barcodePictureBox)
    {
        InFile = inFile;
        RegNum = regNum;
        // OutFile = outFile;
        BarcodePictureBox = barcodePictureBox;
    }

    public void BarcodeDocument()
    {
        /// Без этой строки не поддерживается кодировка Windows 1252
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        BarcodeImage = Barcode.Encode(TYPE.CODE128C, RegNum, Color.Black, Color.White, 100, 34);
        BarcodePictureBox.Image = BarcodeImage;

        BarcodeImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
        XImage image = XImage.FromStream(memoryStream);
        PdfDocument document = PdfReader.Open(InFile, PdfDocumentOpenMode.Modify);
        PdfPage page = document.Pages[0];
        // page.Orientation = PageOrientation.Portrait;
        XGraphics gfx = XGraphics.FromPdfPage(page);

        // double emSize = 48 * 0.35277777777778;//1 point (computer) = 0.35277777777778 millimeter [mm]
        // // int pixelFontSize = 8;
        XFont xFont = new XFont("Calibri", 8, XFontStyle.Regular);

        // XFont font = new XFont(new Font("Calibri", 8));
        XPoint barcodePoint = new XPoint(300, 5);

        gfx.DrawImage(image, barcodePoint);

        gfx.DrawString("#" + RegNum + " " + BarcodeText, xFont, XBrushes.Black, barcodePoint.X, barcodePoint.Y + 34);
        document.Save(InFile);
    }

    // public void NewBarcode()
    // {
    //             // Create an linear barcode object (BarcodeLib.Barcode.Linear)
    //     Barcode.RawData = 

    //     // Set barcode type to Code 39
    //     barcode.Type = BarcodeLib.Barcode.BarcodeType.CODE39;

    //     // Set your encoded barcode value
    //     barcode.Data = "123456789";

    //     // Other barcode settings
    //     // Save barcode image into your system
        
    //     // Draw barcode image into a PNG file
    //     barcode.drawBarcode("c:/barcode.png");
    // }
}