// -----------------------------------------------------------------------------
// Example: Convert slide size inches to points using C#
//
// Description:
// Demonstrates how to convert slide size inches to points using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, Slide, Size, Inches, Points, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of slide size from inches to points.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideSizeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Presentation presentation = new Presentation(inputPath);

                // Custom slide size in inches
                float widthInches = 10.0f;
                float heightInches = 7.5f;

                // Convert inches to points (1 inch = 72 points)
                float widthPoints = widthInches * 72f;
                float heightPoints = heightInches * 72f;

                // Set slide size with scaling to ensure content fits
                presentation.SlideSize.SetSize(widthPoints, heightPoints, SlideSizeScaleType.EnsureFit);

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
