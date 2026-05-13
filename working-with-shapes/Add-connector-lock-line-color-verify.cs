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
                var shape1 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 100, 100, 100);
                var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 200, 120, 80);

                // Add a connector between the shapes
                var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
                connector.StartShapeConnectedTo = shape1;
                connector.EndShapeConnectedTo = shape2;
                connector.Reroute();

                // Set the connector's line color
                connector.LineFormat.FillFormat.FillType = FillType.Solid;
                connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

                // Lock the connector's line format to prevent color changes
                // Using EditPointsLocked as an example to lock modifications
                connector.ShapeLock.EditPointsLocked = true;

                // Save the presentation
                var outputPath = "ConnectorLocked.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported or other exception
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}