// -----------------------------------------------------------------------------
// Example: Add curved connector line angle to variable using C#
//
// Description:
// Demonstrates how to add a curved connector shape to a slide, calculate its
// line angle in degrees, and store the result in a variable using C# and
// Aspose.Slides for .NET. The example shows the required presentation-processing
// steps for PowerPoint files and produces the output presentation in a
// standalone console application. Developers can use this pattern to automate
// PPTX workflows, retrieve connector geometry, or integrate presentation logic
// into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Curved Connector, Line Angle,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate calculation of curved connector line angle.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with connector geometry in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a curved connector to the slide
        Aspose.Slides.IConnector connector = slide.Shapes.AddConnector(Aspose.Slides.ShapeType.CurvedConnector2, 100, 100, 200, 0);

        // Set a simple line width
        connector.LineFormat.Width = 5;

        // Calculate the line angle (in degrees) based on connector dimensions
        double angleRadians = Math.Atan2(connector.Height, connector.Width);
        double angleDegrees = angleRadians * (180.0 / Math.PI);
        double connectorLineAngle = angleDegrees; // Store the angle

        // Save the presentation
        string outputPath = "CurvedConnectorAngle.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
