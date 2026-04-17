using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectShapesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Ensure output directory exists
                string outputDir = Path.GetDirectoryName(Path.GetFullPath("ConnectorInitial.pptx"));
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Access the shapes collection of the first slide
                IShapeCollection shapes = presentation.Slides[0].Shapes;

                // Add an ellipse shape
                IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

                // Add a rectangle shape
                IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 200, 300, 100, 100);

                // Add a curved connector
                IConnector connector = shapes.AddConnector(ShapeType.CurvedConnector2, 0, 0, 10, 10);

                // Connect the shapes
                connector.StartShapeConnectedTo = ellipse;
                connector.EndShapeConnectedTo = rectangle;

                // Enable reroute to calculate the shortest path
                connector.Reroute();

                // Save the initial presentation
                string initialPath = "ConnectorInitial.pptx";
                presentation.Save(initialPath, SaveFormat.Pptx);

                // Move the ellipse to a new position
                ellipse.X = 50;
                ellipse.Y = 150;

                // Reroute again to reflect the new shape positions
                connector.Reroute();

                // Save the updated presentation
                string movedPath = "ConnectorMoved.pptx";
                presentation.Save(movedPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}