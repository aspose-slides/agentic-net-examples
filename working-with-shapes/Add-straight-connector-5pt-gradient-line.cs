// -----------------------------------------------------------------------------
// Example: Add straight connector 5pt gradient line using C#
//
// Description:
// Demonstrates how to add a straight connector with a 5‑point gradient line using
// C# and Aspose.Slides for .NET. The example creates a new presentation, adds a
// straight line connector, sets its line width to 5 pt, applies a linear gradient
// fill from blue to red, and saves the result as a PPTX file. This pattern can be
// used to automate drawing connectors with styled lines in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Straight Connector, Gradient Line,
// Line Width, Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically add straight connectors with custom gradient styling.
// - Build .NET tools that generate or modify PPTX diagrams and flowcharts.
// - Automate visual enhancements for presentations, such as colored connectors.
// - Validate and test presentation rendering before deployment.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Get the shape collection of the slide
            IShapeCollection shapes = slide.Shapes;

            // Add a straight connector to the slide
            IConnector connector = shapes.AddConnector(ShapeType.Line, 100, 100, 200, 0);

            // Set the line width to five points
            connector.LineFormat.Width = 5;

            // Apply a gradient fill to the connector line
            connector.LineFormat.FillFormat.FillType = FillType.Gradient;
            connector.LineFormat.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
            connector.LineFormat.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;
            // Add gradient stops (offset, color)
            connector.LineFormat.FillFormat.GradientFormat.GradientStops.Add(0, PresetColor.Blue);
            connector.LineFormat.FillFormat.GradientFormat.GradientStops.Add(1, PresetColor.Red);

            // Save the presentation
            string outputPath = "StraightConnectorGradient.pptx";
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
