// -----------------------------------------------------------------------------
// Example: Enable ScaleObjectsFit Fit Resize After Changing Slide Size
//
// Description:
// Demonstrates how to change a presentation's slide size while automatically
// scaling existing objects to fit the new dimensions using the EnsureFit
// ScaleObjectsFit option in Aspose.Slides for .NET. The program creates a sample
// PPTX if none exists, applies a new slide size, and saves the result with error handling.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, ScaleObjectsFit, Resize, SlideSize, EnsureFit
//
// Use Cases:
// - Adjust slide dimensions of existing presentations while preserving layout.
// - Build tools that need to re-size slides and automatically scale content.
// - Automate batch processing of PPTX files to a uniform slide size.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace ScaleObjectsFitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Ensure input file exists; create a simple presentation if missing
            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation createPres = new Aspose.Slides.Presentation();
                    createPres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    createPres.Dispose();
                }
                catch (Exception exCreate)
                {
                    Console.WriteLine("Failed to create sample input file: " + exCreate.Message);
                    Environment.Exit(1);
                }
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception exLoad)
            {
                Console.WriteLine("Failed to load presentation: " + exLoad.Message);
                // The provided file format is not supported by Aspose.Slides.
                Environment.Exit(1);
            }

            try
            {
                // Set new slide size (e.g., 960x540 points) and ensure objects are scaled to fit
                presentation.SlideSize.SetSize(960f, 540f, Aspose.Slides.SlideSizeScaleType.EnsureFit);
            }
            catch (Exception exSize)
            {
                Console.WriteLine("Error while setting slide size: " + exSize.Message);
                presentation.Dispose();
                Environment.Exit(1);
            }

            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception exSave)
            {
                Console.WriteLine("Failed to save presentation: " + exSave.Message);
                // The specified save format may not be supported.
                presentation.Dispose();
                Environment.Exit(1);
            }

            // Release resources
            presentation.Dispose();
        }
    }
}
