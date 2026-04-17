using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add two shapes to connect
            IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 100, 100, 100);
            IAutoShape rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 200, 100, 100);

            // Add a connector between the shapes
            IConnector connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;
            connector.Reroute();

            // Set initial line color
            connector.LineFormat.FillFormat.FillType = FillType.Solid;
            connector.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

            // Lock the connector's line format to prevent color changes
            connector.ShapeLock.EditPointsLocked = true;

            // Save the presentation
            string outputPath = "LockedConnector.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}