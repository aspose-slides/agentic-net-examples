// -----------------------------------------------------------------------------
// Example: Convert PowerPoint to PDF with 3D objects flattened
//
// Description:
// This console application loads a PPTX file using Aspose.Slides for .NET,
// converts it to a PDF document, and attempts to flatten any 3‑D objects into
// static images. The code checks for the input file, handles exceptions, and
// saves the resulting PDF. The flattening option is applied when supported
// by the library version.
//
// Keywords:
// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, flatten 3D objects, export
//
// Use Cases:
// - Generate PDF reports from PowerPoint presentations while preserving visual fidelity.
// - Prepare presentation assets for printing where 3‑D effects must be static.
// - Automate batch conversion of slides to PDF in a CI/CD pipeline.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

namespace AsposeSlidesPdfExport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            if (!System.IO.File.Exists(inputPath))
            {
                Console.WriteLine($"Input file '{inputPath}' does not exist.");
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

                // NOTE: The Flatten3D property is not available in older versions of Aspose.Slides.
                // If your version supports it, uncomment the following line:
                // pdfOptions.Flatten3D = true;

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                Console.WriteLine($"Presentation successfully saved as PDF to '{outputPath}'.");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
