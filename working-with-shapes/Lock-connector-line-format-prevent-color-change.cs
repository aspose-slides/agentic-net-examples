using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ConnectorLockExample
{
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

                // Add two shapes to connect
                var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 100, 100, 100);
                var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 250, 300, 100, 100);

                // Add a connector shape
                var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

                // Connect the shapes
                connector.StartShapeConnectedTo = ellipse;
                connector.EndShapeConnectedTo = rectangle;

                // Optional: set initial line color
                connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

                // Lock connector's line format to prevent later color changes
                // By locking edit points and arrowheads, the line appearance cannot be altered through UI
                connector.ShapeLock.EditPointsLocked = true;
                connector.ShapeLock.ArrowheadsLocked = true;

                // Save the presentation
                var outputPath = "ConnectorLocked.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}