using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the shapes collection of the first slide
            Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

            // Add an ellipse shape
            Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);

            // Add a rectangle shape
            Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 300, 100, 100);

            // Add a connector (using BentConnector2 as a straight connector example)
            Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

            // Connect the shapes
            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;

            // Adjust the second adjustment point (ConnectorBendPositionX) to create a custom bend
            if (connector.Adjustments.Count > 1)
            {
                // Example: set the bend position X to 0.5 (represented as 50000 in shape's coordinate system)
                connector.Adjustments[1].RawValue = 50000;
            }

            // Reroute the connector to apply changes
            connector.Reroute();

            // Save the presentation
            string outputPath = "ConnectorAdjustment.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., file I/O errors)
        }
    }
}