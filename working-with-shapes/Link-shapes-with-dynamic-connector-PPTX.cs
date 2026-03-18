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
            var presentation = new Presentation();

            // Access the first slide
            var slide = presentation.Slides[0];

            // Get the shape collection of the slide
            var shapes = slide.Shapes;

            // Add an ellipse shape
            var ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

            // Add a rectangle shape
            var rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

            // Add a bent connector shape
            var connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

            // Connect the shapes
            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;

            // Reroute the connector to the shortest path
            connector.Reroute();

            // Save the presentation
            presentation.Save("ShapesConnector.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}