using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("The input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Save the presentation as PDF
            pres.Save(outputPath, SaveFormat.Pdf);

            // Release resources
            pres.Dispose();

            Console.WriteLine("Presentation successfully converted to PDF: " + outputPath);
        }
    }
}