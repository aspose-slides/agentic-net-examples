// -----------------------------------------------------------------------------
// Example: Export slide as SVG preserving vector data using C#
//
// Description:
// Demonstrates how to export a slide as an SVG file while preserving vector
// data using C# and Aspose.Slides for .NET. The example loads a PowerPoint
// presentation, exports the first slide to SVG with vector data retained, and
// saves the presentation back to its original file. This pattern can be used
// to automate PPTX workflows, generate high‑quality SVG assets, or integrate
// presentation processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Export, Slide, Preserve,
// Vector Data, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of slides to SVG with vector data for scalable graphics.
// - Build C# tools for PowerPoint presentation processing that require
//   high‑fidelity SVG output.
// - Generate or transform PPTX files in .NET applications while retaining
//   vector quality.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToSvgExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output SVG file path
            string outputPath = "slide_1.svg";

            // Verify that the input file exists
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
                    // Set SVG export options to preserve vector data
                    var svgOptions = new SvgExportOptions
                    {
                        VectorData = true
                    };

                    // Export the first slide to SVG with the specified options
                    using (FileStream svgStream = File.Create(outputPath))
                    {
                        presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
                    }

                    // Save the presentation before exiting (as per lifecycle rule)
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Slide exported successfully to SVG: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
