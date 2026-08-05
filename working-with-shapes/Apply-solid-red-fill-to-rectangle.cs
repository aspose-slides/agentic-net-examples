// -----------------------------------------------------------------------------
// Example: Apply solid red fill to rectangle using C#
//
// Description:
// Demonstrates how to create a new presentation, add a rectangle shape, and
// apply a solid red fill to that rectangle using C# and Aspose.Slides for .NET.
// The example shows the required presentation-processing steps for PowerPoint
// files and produces the requested output in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Solid, Fill, Rectangle,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying a solid red fill to a rectangle shape.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();
            // Get the first slide
            ISlide slide = presentation.Slides[0];
            // Add a rectangle shape
            IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
            // Apply solid fill type
            shape.FillFormat.FillType = FillType.Solid;
            // Set fill color to red
            shape.FillFormat.SolidFillColor.Color = Color.Red;
            // Save the presentation
            string outputPath = "SolidRedRectangle.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
