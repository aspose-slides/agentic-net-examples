using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "ConnectedShapes.pptx";

        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the shape collection of the first slide
            IShapeCollection shapes = pres.Slides[0].Shapes;

            // Add sample shapes to the slide
            IAutoShape shape1 = shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
            IAutoShape shape2 = shapes.AddAutoShape(ShapeType.Rectangle, 200, 50, 100, 100);
            IAutoShape shape3 = shapes.AddAutoShape(ShapeType.Rectangle, 350, 50, 100, 100);

            // Retrieve all shapes as an array for sequential processing
            IShape[] shapeArray = shapes.ToArray();

            // Loop through shapes and connect each shape to the next one
            for (int i = 0; i < shapeArray.Length - 1; i++)
            {
                // Add a bent connector
                IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

                // Connect the current shape to the next shape
                connector.StartShapeConnectedTo = shapeArray[i];
                connector.EndShapeConnectedTo = shapeArray[i + 1];

                // Reroute the connector to the shortest path
                connector.Reroute();
            }

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}