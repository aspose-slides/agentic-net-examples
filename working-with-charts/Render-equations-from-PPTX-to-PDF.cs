using System;
using System.IO;
using Aspose.Slides.Export;

namespace RenderEquations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file containing mathematical equations
            string inputPath = "input.pptx";
            // Output PDF file path
            string outputPath = "output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Configure PDF export options with handout layout (one slide per page)
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                Aspose.Slides.Export.HandoutLayoutingOptions layoutOptions = new Aspose.Slides.Export.HandoutLayoutingOptions();
                layoutOptions.Handout = Aspose.Slides.Export.HandoutType.Handouts1; // Correct enum value
                pdfOptions.SlidesLayoutOptions = layoutOptions;

                // Save the presentation as PDF, preserving equation formatting
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }

            Console.WriteLine("PDF successfully saved to: " + outputPath);
        }
    }
}