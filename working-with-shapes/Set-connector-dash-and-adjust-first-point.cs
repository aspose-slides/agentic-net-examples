using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add two shapes to be connected
        Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);
        Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 300, 100, 100);

        // Add a bent connector and connect the shapes
        Aspose.Slides.IConnector connector = slide.Shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;
        connector.Reroute();

        // Apply a dashed line style to the connector
        connector.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;

        // Adjust the first adjustment point (e.g., bend position)
        if (connector.Adjustments.Count > 0)
        {
            // Adjustment values are mutable; set a raw value as an example
            connector.Adjustments[0].RawValue = 5000;
        }

        // Save the presentation
        string outputPath = "ConnectorDashAdjust.pptx";
        try
        {
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions such as unsupported format or I/O errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}