using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the existing presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access the shape collection of the first slide
                IShapeCollection shapes = presentation.Slides[0].Shapes;

                // Add an ellipse shape
                IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

                // Add a rectangle shape
                IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

                // Add a bent connector shape
                IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

                // Connect the shapes using the connector
                connector.StartShapeConnectedTo = ellipse;
                connector.EndShapeConnectedTo = rectangle;
                connector.Reroute();

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}