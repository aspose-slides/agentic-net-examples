using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pdf";

                // Load the PPTX presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Stream the PDF output into a memory stream (BLOB)
                    using (MemoryStream pdfStream = new MemoryStream())
                    {
                        // Save presentation as PDF into the stream
                        presentation.Save(pdfStream, Aspose.Slides.Export.SaveFormat.Pdf);

                        // Write the PDF BLOB to a file
                        File.WriteAllBytes(outputPath, pdfStream.ToArray());
                    }

                    // Ensure the presentation is saved before exiting
                    presentation.Save("temp_save.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}