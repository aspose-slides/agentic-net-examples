// -----------------------------------------------------------------------------
// Example: Enable ScaleObjectsFit fit resize after slide size using C#
//
// Description:
// Demonstrates how to change a presentation's slide size while automatically
// scaling existing objects to fit the new dimensions using the EnsureFit
// ScaleObjectsFit option in Aspose.Slides for .NET. The sample loads a PPTX,
// applies a new slide size, saves the result, and includes basic error handling.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Enable, ScaleObjectsFit, Resize,
// SlideSize, EnsureFit, Presentation Processing, Office Automation
//
// Use Cases:
// - Adjust slide dimensions of existing presentations while preserving layout.
// - Build tools that need to re‑size slides and automatically scale content.
// - Automate batch processing of PPTX files to a uniform slide size.
// - Validate that scaling behaves as expected before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ScaleObjectsFitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Format not supported comment
                // The provided file format is not supported by Aspose.Slides.
                return;
            }

            try
            {
                // Change slide dimensions and automatically resize objects to fit
                // Using EnsureFit scale type to fit existing content
                presentation.SlideSize.SetSize(960f, 540f, SlideSizeScaleType.EnsureFit);
            }
            catch (Exception ex)
            {
                // Handle any errors while setting slide size
                Console.WriteLine("Error while setting slide size: " + ex.Message);
                presentation.Dispose();
                return;
            }

            try
            {
                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation: " + ex.Message);
                // Format not supported comment
                // The specified save format may not be supported.
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
