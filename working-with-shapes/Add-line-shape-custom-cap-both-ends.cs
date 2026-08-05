// -----------------------------------------------------------------------------
// Example: Add line shape custom cap both ends using C#
//
// Description:
// Demonstrates how to add a line shape with a custom square cap on both ends 
// using C# and Aspose.Slides for .NET. The example creates a new presentation, 
// inserts a line shape, sets its width and cap style, and saves the result as a 
// PPTX file. This pattern can be used to automate PowerPoint line formatting 
// tasks in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line Shape, Custom Cap, Both Ends, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding line shapes with custom caps to presentations.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or modify PPTX files programmatically in .NET.
// - Ensure consistent line styling across slides before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddCustomLineCap
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                var presentation = new Presentation();

                // Get the first slide
                var slide = presentation.Slides[0];

                // Add a line shape
                var line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

                // Set line width
                line.LineFormat.Width = 5;

                // Set custom line cap style for both ends
                line.LineFormat.CapStyle = LineCapStyle.Square;

                // Save the presentation
                var outputPath = "CustomLineCap.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
