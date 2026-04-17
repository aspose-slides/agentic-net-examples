using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "ConnectorBend.pptx";

        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the shapes collection of the first slide
            IShapeCollection shapes = pres.Slides[0].Shapes;

            // Add two shapes to connect
            IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
            IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 200, 300, 100, 100);

            // Add a bent connector between the shapes
            IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;

            // Adjust the second adjustment point (custom bend)
            if (connector.Adjustments.Count > 1)
            {
                // The second adjustment typically controls the bend position
                if (connector.Adjustments[1].Type == ShapeAdjustmentType.ConnectorBendPositionX)
                {
                    // Set a custom X bend position (value in shape's coordinate system)
                    connector.Adjustments[1].RawValue = 5000;
                }
                else if (connector.Adjustments[1].Type == ShapeAdjustmentType.ConnectorBendPositionY)
                {
                    // Set a custom Y bend position
                    connector.Adjustments[1].RawValue = 3000;
                }
            }

            // Reroute the connector to apply changes
            connector.Reroute();

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other errors
        }
    }
}