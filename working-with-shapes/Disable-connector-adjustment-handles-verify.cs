using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the shapes collection of the first slide
        IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add an ellipse shape
        IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

        // Add a rectangle shape
        IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

        // Add a bent connector and connect the shapes
        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;
        connector.Reroute();

        // Iterate through all shapes and disable adjustment handles for connectors
        for (int i = 0; i < shapes.Count; i++)
        {
            Shape shape = (Shape)shapes[i];
            if (shape is Connector)
            {
                Connector conn = (Connector)shape;
                // Disable adjustment handles
                conn.ConnectorLock.AdjustHandlesLocked = true;

                // Verify that the handles are locked
                bool isLocked = conn.ConnectorLock.AdjustHandlesLocked;
                Console.WriteLine("Connector at index " + i + " adjustment handles locked: " + isLocked);
            }
        }

        // Save the presentation
        string outputPath = "ConnectorsLocked.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}