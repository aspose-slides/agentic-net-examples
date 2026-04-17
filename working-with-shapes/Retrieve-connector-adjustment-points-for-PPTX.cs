using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the shape collection of the first slide
        Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Define the connector types to examine
        Aspose.Slides.ShapeType[] connectorTypes = new Aspose.Slides.ShapeType[]
        {
            Aspose.Slides.ShapeType.BentConnector2,
            Aspose.Slides.ShapeType.StraightConnector1,
            Aspose.Slides.ShapeType.CurvedConnector2
        };

        // Iterate over each connector type, add a connector, and log its adjustment count
        foreach (Aspose.Slides.ShapeType connectorType in connectorTypes)
        {
            Aspose.Slides.IConnector connector = shapes.AddConnector(connectorType, 0, 0, 10, 10);
            int adjustmentCount = connector.Adjustments.Count;
            Console.WriteLine("Connector type " + connectorType + " has " + adjustmentCount + " adjustment points.");
        }

        // Save the presentation
        try
        {
            presentation.Save("ConnectorAdjustments.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}