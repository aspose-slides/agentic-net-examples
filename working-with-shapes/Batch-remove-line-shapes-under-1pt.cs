// -----------------------------------------------------------------------------
// Example: Batch remove line shapes under 1pt using C#
//
// Description:
// Demonstrates how to batch remove line shapes under 1pt using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Batch, Remove, Line, Shapes, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate batch remove line shapes under 1pt.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveThinLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception)
            {
                // Format not supported or file could not be opened
                Console.WriteLine("Failed to load presentation. The file format may not be supported.");
                return;
            }

            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];

                // Iterate backwards to safely remove shapes
                for (int shapeIndex = slide.Shapes.Count - 1; shapeIndex >= 0; shapeIndex--)
                {
                    IShape shape = slide.Shapes[shapeIndex];

                    // Check if shape has a line format and its width is less than 1 point
                    if (shape.LineFormat != null && shape.LineFormat.Width < 1.0f)
                    {
                        slide.Shapes.Remove(shape);
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}
