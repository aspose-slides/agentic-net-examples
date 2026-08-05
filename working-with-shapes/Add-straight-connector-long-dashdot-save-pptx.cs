// -----------------------------------------------------------------------------
// Example: Add straight connector long dashdot save pptx using C#
//
// Description:
// Demonstrates how to add a straight connector with a long dash‑dot line style
// to a slide and save the presentation as PPTX using C# and Aspose.Slides for .NET.
// The example creates a new presentation, inserts a connector, configures its
// dash style, and writes the result to a file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Straight, Connector, Long,
// Dashdot, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding straight connectors with long dash‑dot styling to PPTX files.
// - Build C# utilities for PowerPoint presentation manipulation.
// - Generate or modify PPTX content programmatically in .NET applications.
// - Validate connector styling in automated presentation workflows.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Get the shape collection of the slide
        IShapeCollection shapes = slide.Shapes;

        // Add a straight connector (using BentConnector2 as a straight line)
        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 100, 100, 200, 0);

        // Set the line dash style to long dash dot
        connector.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.LargeDashDot;

        // Save the presentation
        string outputPath = "ConnectorDemo.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}
