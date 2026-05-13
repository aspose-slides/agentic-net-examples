using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "CurvedConnector.pptx";
        try
        {
            Presentation presentation = new Presentation();
            IShapeCollection shapes = presentation.Slides[0].Shapes;

            // Add shapes to connect
            IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 50, 100, 100, 100);
            IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 300, 250, 100, 100);

            // Add a curved connector
            IConnector connector = shapes.AddConnector(ShapeType.CurvedConnector2, 0, 0, 10, 10);
            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;
            connector.Reroute();

            // Set line width to three points (visual thickness verification via inspection)
            connector.LineFormat.Width = 3;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // General exception handling
        }
    }
}