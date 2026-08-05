// -----------------------------------------------------------------------------
// Example: Set master slide dashdot pattern using C#
//
// Description:
// Demonstrates how to set the line dash style to DashDot for all shapes on
// each master slide in a PowerPoint presentation using Aspose.Slides for .NET.
// The example loads an existing PPTX file, updates the line formatting of
// shapes on master slides, and saves the result as a new PPTX file.
// This is useful for ensuring consistent line styling across master slides.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Master Slide, Shape, Line,
// DashDot, LineDashStyle, Presentation Processing, Office Automation
//
// Use Cases:
// - Apply a uniform DashDot line style to all shapes on master slides.
// - Prepare presentations with consistent styling before distribution.
// - Automate styling updates in batch processing of PPTX files.
// - Integrate line style adjustments into .NET-based PowerPoint tooling.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceLineDashOnMaster
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

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Iterate through all master slides
                foreach (IMasterSlide masterSlide in pres.Masters)
                {
                    // Iterate through all shapes on the master slide
                    foreach (IShape shape in masterSlide.Shapes)
                    {
                        // Set the line dash style to DashDot for consistency
                        shape.LineFormat.DashStyle = LineDashStyle.DashDot;
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
