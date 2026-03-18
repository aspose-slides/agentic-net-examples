using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];
                // Get the shapes collection
                IShapeCollection shapes = slide.Shapes;

                // Add an ellipse shape
                IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
                // Add a rectangle shape
                IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

                // Add a bent connector shape
                IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
                // Set the connector type explicitly (optional)
                connector.ShapeType = ShapeType.BentConnector2;

                // Connect the shapes
                connector.StartShapeConnectedTo = ellipse;
                connector.EndShapeConnectedTo = rectangle;

                // Reroute the connector to the shortest path
                connector.Reroute();

                // Save the presentation
                presentation.Save("ConnectorExample.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}