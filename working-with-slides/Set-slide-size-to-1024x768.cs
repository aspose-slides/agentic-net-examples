// -----------------------------------------------------------------------------
// Example: Set slide size to 1024x768 using C#
//
// Description:
// Demonstrates how to load an existing PPTX file, set its slide size to
// 1024x768 points using Aspose.Slides for .NET, and save the modified
// presentation. The example includes basic error handling for missing files
// and unsupported formats, suitable for console applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide, Size, 1024x768,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Resize existing PowerPoint presentations to a standard 1024x768 size.
// - Build .NET tools that adjust slide dimensions for consistency across decks.
// - Automate PPTX preprocessing before publishing or further manipulation.
// - Validate slide size settings in CI pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideSizeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Set custom slide size to 1024x768 points with content scaling to ensure fit
                    presentation.SlideSize.SetSize(1024f, 768f, SlideSizeScaleType.EnsureFit);

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
