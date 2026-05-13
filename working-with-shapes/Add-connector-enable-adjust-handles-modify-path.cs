using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the shape collection of the first slide
        Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add two shapes to be connected
        Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);
        Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 300, 100, 100);

        // Add a bent connector
        Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the shapes
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;

        // Enable adjustment handles (unlock them)
        connector.ShapeLock.AdjustHandlesLocked = false;

        // Modify adjustment values if they exist
        if (connector.Adjustments.Count > 0)
        {
            Aspose.Slides.IAdjustValue firstAdjustment = connector.Adjustments[0];
            // Example modification: increase angle value
            firstAdjustment.AngleValue = firstAdjustment.AngleValue + 10;
        }

        if (connector.Adjustments.Count > 1)
        {
            Aspose.Slides.IAdjustValue secondAdjustment = connector.Adjustments[1];
            // Example modification: decrease angle value
            secondAdjustment.AngleValue = secondAdjustment.AngleValue - 5;
        }

        // Reroute the connector to apply changes
        connector.Reroute();

        // Retrieve geometry paths to confirm the new shape (can be inspected if needed)
        Aspose.Slides.IGeometryPath[] geometryPaths = connector.GetGeometryPaths();

        // Save the presentation
        try
        {
            presentation.Save("ConnectorAdjustments.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other save error
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}