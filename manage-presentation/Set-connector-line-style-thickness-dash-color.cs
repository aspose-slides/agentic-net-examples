// -----------------------------------------------------------------------------
// Example: Set connector line style thickness dash color using C#
//
// Description:
// Demonstrates how to set a connector's line style—including thickness, dash
// pattern, and color—using C# and Aspose.Slides for .NET. The example creates a
// new presentation, adds a bent connector, configures its line format, and
// saves the result as a PPTX file. This pattern can be used to automate
// PowerPoint presentation styling in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Connector, Line, Style,
// Thickness, Dash, Color, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting connector line thickness, dash style, and color.
// - Build C# utilities for PowerPoint presentation styling.
// - Generate or modify PPTX files programmatically in .NET.
// - Validate visual consistency of connectors before publishing.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectorLineStyleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Access the shape collection of the slide
                Aspose.Slides.IShapeCollection shapes = slide.Shapes;

                // Add a bent connector shape
                Aspose.Slides.IConnector connector = shapes.AddConnector(
                    Aspose.Slides.ShapeType.BentConnector2,
                    0f, 0f, 200f, 0f);

                // Set line thickness
                connector.LineFormat.Width = 5.0;

                // Set dash pattern
                connector.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;

                // Set line color
                connector.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                connector.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

                // Save the presentation
                string outputPath = "ConnectorLineStyle.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
