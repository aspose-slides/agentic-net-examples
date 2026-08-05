// -----------------------------------------------------------------------------
// Example: Add dashed connector adjust first point using C#
//
// Description:
// Demonstrates how to add a dashed connector between two shapes and adjust the
// first adjustment point using C# and Aspose.Slides for .NET. The example shows
// the required presentation-processing steps for PowerPoint files and produces
// the requested output in a standalone console application. Developers can use
// this pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Dashed, Connector, Adjust, 
// First, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a dashed connector and adjusting its first point.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation())
            {
                ISlide slide = presentation.Slides[0];

                // Add two shapes to connect
                IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 100, 50);
                IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 300, 150, 100, 50);

                // Add a straight connector
                IConnector connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 0, 0, 10, 10);

                // Connect the shapes
                connector.StartShapeConnectedTo = shape1;
                connector.EndShapeConnectedTo = shape2;

                // Apply dashed line style
                connector.LineFormat.DashStyle = LineDashStyle.Dash;

                // Adjust the first adjustment point (e.g., bend position X)
                if (connector.Adjustments.Count > 0)
                {
                    // RawValue expects an Int64; 50000 represents 50% of the shape's dimension
                    connector.Adjustments[0].RawValue = 50000;
                }

                // Save the presentation
                presentation.Save("DashedConnector.pptx", SaveFormat.Pptx);
            }
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
