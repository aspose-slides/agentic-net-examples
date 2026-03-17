using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlidesToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file
            string inputPath = "input.pptx";
            // Output PDF file
            string outputPath = "selected_slides.pdf";
            // Slides to export (1‑based indices)
            int[] slideIndices = new int[] { 1, 3, 5 };

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Export the specified slides to PDF
                    presentation.Save(outputPath, slideIndices, SaveFormat.Pdf);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}