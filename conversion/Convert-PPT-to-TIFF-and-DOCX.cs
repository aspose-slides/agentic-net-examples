// -----------------------------------------------------------------------------
// Example: Convert PowerPoint Presentation to Multi-Page TIFF and Attempt DOCX
//
// Description:
// This console application loads a PPT or PPTX file using Aspose.Slides for .NET,
// saves the presentation as a multi-page TIFF image, and attempts to save it as
// a DOCX document. It includes checks for the existence of the input file and
// handles unsupported format scenarios gracefully.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, TIFF conversion, DOCX conversion, presentation automation
//
// Use Cases:
// - Automating batch conversion of presentations to image formats for archival.
// - Preparing presentation content for inclusion in document workflows.
// - Demonstrating error handling when a target format is not supported by the library.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string tiffOutputPath = "output.tiff";
            string docxOutputPath = "output.docx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: The input file \"{inputPath}\" does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Save as multi-page TIFF
                presentation.Save(tiffOutputPath, Aspose.Slides.Export.SaveFormat.Tiff);
                Console.WriteLine($"Presentation successfully saved as TIFF: {tiffOutputPath}");

                // Attempt to save as DOCX
                // Note: Aspose.Slides does not provide a SaveFormat for DOCX; this block
                // demonstrates handling of an unsupported format scenario.
                try
                {
                    // The following line is intentionally commented out because
                    // Aspose.Slides.Export.SaveFormat does not define a Docx member.
                    // presentation.Save(docxOutputPath, Aspose.Slides.Export.SaveFormat.Docx);

                    // If future versions add DOCX support, uncomment the line above.
                    Console.WriteLine("DOCX conversion is not supported by the current Aspose.Slides version.");
                }
                catch (Exception exDocx)
                {
                    Console.WriteLine($"DOCX conversion failed: {exDocx.Message}");
                }

                // Ensure the presentation is disposed
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during conversion: {ex.Message}");
            }
        }
    }
}
