using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectorValidationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Prepare output directory
                string dataDir = "Data";
                if (!Directory.Exists(dataDir))
                {
                    Directory.CreateDirectory(dataDir);
                }

                // Output file path
                string outPath = Path.Combine(dataDir, "ConnectorMoveDemo.pptx");

                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Get the shape collection of the slide
                IShapeCollection shapes = slide.Shapes;

                // Add an ellipse shape
                IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

                // Add a rectangle shape
                IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

                // Add a bent connector
                IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

                // Connect the shapes
                connector.StartShapeConnectedTo = ellipse;
                connector.EndShapeConnectedTo = rectangle;
                connector.Reroute();

                // Move the source shape (ellipse) by a specified offset
                float offsetX = 50f;
                float offsetY = 30f;
                ellipse.X += offsetX;
                ellipse.Y += offsetY;

                // Validate that the connector is still attached to the moved shape
                bool stillConnected = Object.ReferenceEquals(connector.StartShapeConnectedTo, ellipse);
                Console.WriteLine("Connector still attached after moving source shape: " + stillConnected);

                // Save the presentation
                pres.Save(outPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}