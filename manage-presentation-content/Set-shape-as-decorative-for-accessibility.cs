// -----------------------------------------------------------------------------
// Example: Set shape as decorative for accessibility using C#
//
// Description:
// Demonstrates how to set shape as decorative for accessibility using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Shape, Decorative, 
// Accessibility, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set shape as decorative for accessibility.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DecorativeShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "DecorativeShape.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a rectangle auto shape to the first slide
                IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                    ShapeType.Rectangle, 100, 100, 300, 150);

                // Mark the shape as decorative for accessibility compliance
                shape.IsDecorative = true;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
