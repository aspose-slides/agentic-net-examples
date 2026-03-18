using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideImportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source file (e.g., PDF)
            string sourcePath = "source.pdf";
            // Path to the output PPTX file
            string outputPath = "output.pptx";

            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Import slides from the source PDF file
                    presentation.Slides.AddFromPdf(sourcePath);
                    // Save the presentation as PPTX while preserving fidelity
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}