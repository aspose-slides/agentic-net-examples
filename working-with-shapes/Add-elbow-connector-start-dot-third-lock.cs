using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectShapesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the shape collection of the first slide
            IShapeCollection shapes = presentation.Slides[0].Shapes;

            // Add a rectangle shape (has connection sites)
            IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 150, 100);

            // Add an elbow (bent) connector
            IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

            // Connect the start of the connector to the rectangle
            connector.StartShapeConnectedTo = rectangle;

            // Set the start connection site to the third site (index 2)
            connector.StartShapeConnectionSiteIndex = 2u;

            // Lock the connector to prevent moving
            connector.ShapeLock.PositionMove = true;

            // Save the presentation
            try
            {
                presentation.Save("ConnectedShapes.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other save errors
                // Format not supported.
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}