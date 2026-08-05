// -----------------------------------------------------------------------------
// Example: Get curved connector angle after move using C#
//
// Description:
// Demonstrates how to get curved connector angle after move using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Curved, Connector, Angle, 
// After, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate get curved connector angle after move.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];
        // Add two shapes to be connected
        Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);
        Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 300, 100, 100);
        // Add a curved connector
        Aspose.Slides.IConnector connector = slide.Shapes.AddConnector(Aspose.Slides.ShapeType.CurvedConnector2, 0, 0, 10, 10);
        // Connect the shapes
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;
        // Move the attached shapes to new positions
        ellipse.X = 50;
        ellipse.Y = 150;
        rectangle.X = 300;
        rectangle.Y = 350;
        // Reroute the connector to adjust its path
        connector.Reroute();
        // Retrieve the angle of the connector
        double angle = GetDirection(connector.Width, connector.Height,
            System.Convert.ToBoolean(connector.Frame.FlipH), System.Convert.ToBoolean(connector.Frame.FlipV));
        // Output the angle
        System.Console.WriteLine("Connector angle: " + angle);
        // Save the presentation
        pres.Save("ConnectorAngle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }

    // Helper method to calculate direction angle in degrees
    private static double GetDirection(float width, float height, bool flipH, bool flipV)
    {
        double dx = width;
        double dy = height;
        if (flipH) dx = -dx;
        if (flipV) dy = -dy;
        double radians = Math.Atan2(dy, dx);
        double degrees = radians * (180.0 / Math.PI);
        return degrees;
    }
}
