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

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create and add text in PDF File Also Add the signature
            //const string Name = "Ali";
            //string Age = "25";
            //string Address = "Jinnah gate pasrur";
            //string newLine = "\r\n";
            //string sample = "Signature:" + Name + " " + newLine + "Age:" + Age + " " + newLine + " Address: " + Address + " " + newLine;
            //const string text =

            //    "Facin exeraessisit la consenim iureet dignibh eu facilluptat vercil dunt autpat. " +

            //    "Ecte magna faccum dolor sequisc iliquat, quat, quipiss equipit accummy niate magna " +

            //    "facil iure eraesequis am velit, quat atis dolore dolent luptat nulla adio odipissectet " +

            //    "lan venis do essequatio conulla facillandrem zzriusci bla ad minim inis nim velit eugait ";

            //GlobalFontSettings.FontResolver = new FontResolver();
            //AnnotationCopyingType acp = AnnotationCopyingType.DoNotCopy;
            //PdfSharpCore.Pdf.PdfPage pdfp = new PdfSharpCore.Pdf.PdfPage();

            //var document = new PdfSharpCore.Pdf.PdfDocument();
            //var page = document.AddPage(pdfp, acp);
            //var gfx = XGraphics.FromPdfPage(page);
            //var font = new XFont("OpenSans", 10, XFontStyle.Bold);
            //XTextFormatter tf = new XTextFormatter(gfx);
            //XRect rect = new XRect(40, 100, 480, 220);
            //gfx.DrawRectangle(XBrushes.SeaShell, rect);
            //tf.DrawString(text, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            //gfx.DrawString("Name:"+Name, font, XBrushes.Black, new XRect(20, 20, page.Width,0), XStringFormats.TopLeft);
            //gfx.DrawString("Age:"+Age, font, XBrushes.Black, new XRect(20, 35, page.Width,0), XStringFormats.TopLeft);
            //gfx.DrawString("Address"+Address, font, XBrushes.Black, new XRect(20, 50, page.Width,0), XStringFormats.TopLeft);
            //document.Save("test.pdf");
            //Create and add text in PDF File Also Add the signature End 



            //verification PDF Start
            string fileName = @"C:\Users\falcon\source\repos\ConsoleApp3\ConsoleApp3\bin\Debug\netcoreapp3.1\test.pdf";
            string searthText = "Alis";
            string searchAge = "25";
            string searchAddress = "Jinnah gate pasrur";
            List<int> pages = new List<int>();
            if (File.Exists(fileName))
            {
                PdfReader pdfReader = new PdfReader(fileName);
                for (int pageIndex = 1; pageIndex <= pdfReader.NumberOfPages; pageIndex++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                    string currentPageText = PdfTextExtractor.GetTextFromPage(pdfReader, pageIndex, strategy);
                    if (currentPageText.Contains(searthText) && currentPageText.Contains(searchAge) && currentPageText.Contains(searchAddress))
                    {
                        Console.WriteLine("True");
                        //pages.Add(page);
                    }
                    else
                    {
                        Console.WriteLine("false");
                    }
                }
                pdfReader.Close();
            }
            //verification PDF End

            //Show the Text of PDF File
            //var ExtractedPDFToString = ExtractTextFromPdf(@"C:\Users\falcon\source\repos\ConsoleApp3\ConsoleApp3\bin\Debug\netcoreapp3.1\test.pdf");
            //Console.WriteLine(ExtractedPDFToString);


        }

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

