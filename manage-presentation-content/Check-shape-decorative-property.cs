// -----------------------------------------------------------------------------
// Example: Check shape decorative property using C#
//
// Description:
// Demonstrates how to check the decorative property of each shape in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example loads a PPTX file,
// iterates through all slides and shapes, outputs whether each shape is marked as
// decorative, and saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Check, Shape, Decorative, 
// Property, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate verification of shape decorative settings in presentations.
// - Build C# tools for PowerPoint accessibility compliance checks.
// - Generate reports on shape properties for content auditing.
// - Integrate shape property validation into .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeDecorativeCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
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
                Presentation presentation = new Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape is marked as decorative
                        bool isDecorative = shape.IsDecorative;
                        Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1} - IsDecorative: {isDecorative}");
                    }
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}
