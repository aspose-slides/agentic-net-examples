using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "ConnectorAngleDemo.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add two shapes to be connected
        IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 100, 100, 100);
        IAutoShape rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 250, 120, 80);

        // Add a curved connector and connect the shapes
        IConnector connector = slide.Shapes.AddConnector(ShapeType.CurvedConnector2, 0, 0, 10, 10);
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;
        connector.Reroute();

        // Move the connected shapes to new positions
        ellipse.X = 150;
        ellipse.Y = 200;
        rectangle.X = 400;
        rectangle.Y = 350;

        // Reroute the connector after moving the shapes
        connector.Reroute();

        // Retrieve the angle of the curved connector
        double angle = GetDirection(connector.Width, connector.Height,
            System.Convert.ToBoolean(connector.Frame.FlipH),
            System.Convert.ToBoolean(connector.Frame.FlipV));

        Console.WriteLine("Connector angle: " + angle);

        // Save the presentation (handle unsupported format)
        try
        {
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Format not supported or other save error
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        pres.Dispose();
    }

    // Helper method to calculate direction angle based on width, height and flip flags
    private static double GetDirection(double width, double height, bool flipH, bool flipV)
    {
        double angle = Math.Atan2(height, width) * (180.0 / Math.PI);
        if (flipH)
        {
            angle = 180 - angle;
        }
        if (flipV)
        {
            angle = -angle;
        }
        return angle;
    }
}