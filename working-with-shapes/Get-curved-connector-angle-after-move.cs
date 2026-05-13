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