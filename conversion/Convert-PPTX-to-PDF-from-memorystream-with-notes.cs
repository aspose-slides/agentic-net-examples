using System;
using System.IO;
using Aspose.Slides.Export;

namespace ConvertPptxToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                    pdfOptions.ShowHiddenSlides = true;
                    pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions
                    {
                        NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull
                    };

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        presentation.Save(memoryStream, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                        File.WriteAllBytes(outputPath, memoryStream.ToArray());
                    }

                    presentation.Dispose();
                }
            }
            catch (NotSupportedException)
            {
                // format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}