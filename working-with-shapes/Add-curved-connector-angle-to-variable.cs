using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Get the shapes collection of the slide
        IShapeCollection shapes = slide.Shapes;

        // Add a curved connector to the slide
        IConnector connector = shapes.AddConnector(ShapeType.CurvedConnector2, 100, 100, 200, 0);
        connector.Reroute();

        // Retrieve the line angle of the connector
        double angle = GetDirection(connector.Width, connector.Height,
            Convert.ToBoolean(connector.Frame.FlipH), Convert.ToBoolean(connector.Frame.FlipV));

        // Save the presentation
        try
        {
            presentation.Save("CurvedConnector.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex) when (ex is NotSupportedException)
        {
            // Format not supported
        }
    }

    // Helper method to calculate direction angle in degrees
    private static double GetDirection(float width, float height, bool flipH, bool flipV)
    {
        double radians = Math.Atan2(height, width);
        double degrees = radians * (180.0 / Math.PI);
        if (flipH) degrees = 180 - degrees;
        if (flipV) degrees = -degrees;
        return degrees;
    }
}