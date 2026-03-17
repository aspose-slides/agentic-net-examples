using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inputPath = "large.pptx";
                var outputPath = "output.pdf";

                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    using (var pdfStream = new MemoryStream())
                    {
                        // Export presentation to PDF using a memory stream (BLOB)
                        presentation.Save(pdfStream, Aspose.Slides.Export.SaveFormat.Pdf);

                        // Optionally write the stream to a file
                        File.WriteAllBytes(outputPath, pdfStream.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}