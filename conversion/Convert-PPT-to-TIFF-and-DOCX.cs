// -----------------------------------------------------------------------------
// Example: Convert PPT to TIFF and DOCX using C#
//
// Description:
// Demonstrates how to convert a PowerPoint presentation (PPT/PPTX) to a
// multi-page TIFF image and to a DOCX document using Aspose.Slides for .NET.
// The example loads a presentation, saves it as TIFF, then saves it as DOCX,
// handling basic file‑existence checks and error reporting in a console
// application. This pattern can be used to automate presentation conversion
// workflows in .NET projects.
//
// Keywords:
// C#, PowerPoint, PPT, PPTX, Aspose.Slides for .NET, TIFF, DOCX, Convert,
// Presentation Processing, Office Automation, .NET Console
//
// Use Cases:
// - Automate conversion of PPT/PPTX files to TIFF for image‑based distribution.
// - Generate DOCX documents from PowerPoint presentations for text‑based review.
// - Build C# utilities that process and transform PowerPoint files in batch.
// - Validate presentation conversion steps before integrating into larger systems.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPT file path
            string inputPath = "input.ppt";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Output file paths
            string outputTiff = "output.tiff";
            string outputDocx = "output.docx";

            try
            {
                // Load the presentation once and reuse it
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Convert to TIFF
                    presentation.Save(outputTiff, SaveFormat.Tiff);

                    // Convert to DOCX
                    presentation.Save(outputDocx, SaveFormat.Docx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
