using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Fonts;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Utils;
using System;
using System.Diagnostics;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

using System.IO;
using PdfReader = iTextSharp.text.pdf.PdfReader;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata;
using Spire.Pdf.Security;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

           
            #region Create and add text in PDF File Also Add the signature
            const string Name = "Verifyied By RegistreRH";
            var image = XImage.FromFile("verify.pdf");
            PdfCertificate cert = new PdfCertificate("FalconITConsulting.pfx", "12as34df56gh");
            Certificate certificate = new Certificate();
            certificate.IssuerName = cert.IssuerName;
            certificate.Subject = cert.Subject;
            certificate.SerialNumber = cert.SerialNumber;
            certificate.ThumbPrint = cert.Thumbprint;
            certificate.Version = cert.Version;
            certificate.PublicKey = cert.PublicKey;
            certificate.certStartDate = cert.NotBefore;
            certificate.certEndDate = cert.NotAfter;
            Console.WriteLine(certificate);
            //var Subejct = cert.Subject;
            //string Age = "25";
            //string Address = "Jinnah gate pasrur";
            //string newLine = "\r\n";
            //string sample = "Signature:" + Name + " " + newLine + "Age:" + Age + " " + newLine + " Address: " + Address + " " + newLine;
            const string text = "PDF Descrition you can provide html and then convert it into PDF";
            GlobalFontSettings.FontResolver = new FontResolver();
            AnnotationCopyingType acp = AnnotationCopyingType.DoNotCopy;
            PdfSharpCore.Pdf.PdfPage pdfp = new PdfSharpCore.Pdf.PdfPage();
            var document = new PdfSharpCore.Pdf.PdfDocument();
            var page = document.AddPage(pdfp, acp);
            var gfx = XGraphics.FromPdfPage(page);
            var font = new XFont("OpenSans", 10, XFontStyle.Bold);
            XTextFormatter tf = new XTextFormatter(gfx);
            XRect rect = new XRect(40, 100, 480, 220);
            double width = image.PixelWidth * 5.9 / image.HorizontalResolution;
            double height = image.PixelHeight * 5.9 / image.HorizontalResolution;
            //Draw the Image of Verify
            gfx.DrawImage(image, 450, page.Height - 60, width, height);
            //Draw the Text of Document
            tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);
            //Draw the Verification Signature of RegistreRH
            gfx.DrawString( Name, font, XBrushes.Black, new XRect(10, 10, page.Width-20, page.Height-50),XStringFormats.BottomRight);
            document.Save("test3.pdf");
            #endregion

            //#region verification PDF Start
            //string fileName = @"C:\Users\falcon\source\repos\ConsoleApp3\ConsoleApp3\bin\Debug\netcoreapp3.1\test.pdf";
            //string searthText = "Ali";
            //string searchAge = "25";
            //string searchAddress = "Jinnah gate pasrur";
            //List<int> pages = new List<int>();
            //if (File.Exists(fileName))
            //{
            //    PdfReader pdfReader = new PdfReader(fileName);
            //    for (int pageIndex = 1; pageIndex <= pdfReader.NumberOfPages; pageIndex++)
            //    {
            //        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

            //        string currentPageText = PdfTextExtractor.GetTextFromPage(pdfReader, pageIndex, strategy);
            //        if (currentPageText.Contains(searthText) && currentPageText.Contains(searchAge) && currentPageText.Contains(searchAddress))
            //        {
            //            Console.WriteLine("True");
            //            //pages.Add(page);
            //        }
            //        else
            //        {
            //            Console.WriteLine("false");
            //        }
            //    }
            //    pdfReader.Close();
            //}
            //#endregion

            //#region Show the Text of PDF File
            //var ExtractedPDFToString = ExtractTextFromPdf(@"C:\Users\falcon\source\repos\ConsoleApp3\ConsoleApp3\bin\Debug\netcoreapp3.1\test.pdf");
            //Console.WriteLine(ExtractedPDFToString);
            //#endregion


        }
        #region ExtractTextFromPdf
        private static string ExtractTextFromPdf(string path)
        {
            using (PdfReader reader = new PdfReader(path))
            {
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }

                return text.ToString();
            }
        }
        #endregion

        //public List<int> ReadPdfFile(string fileName, String searthText)
        //{
        //    List<int> pages = new List<int>();
        //    if (File.Exists(fileName))
        //    {
        //        PdfReader pdfReader = new PdfReader(fileName);
        //        for (int page = 1; page <= pdfReader.NumberOfPages; page++)
        //        {
        //            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

        //            string currentPageText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
        //            if (currentPageText.Contains(searthText))
        //            {
        //                pages.Add(page);
        //            }
        //        }
        //        pdfReader.Close();
        //    }
        //    return pages;
        //}
    }
}

