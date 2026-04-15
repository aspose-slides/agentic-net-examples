using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Presentation presentation = new Presentation();
            IShapeCollection shapes = presentation.Slides[0].Shapes;
            IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
            IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 200, 300, 100, 100);
            IConnector connector = shapes.AddConnector(ShapeType.CurvedConnector2, 0, 0, 10, 10);
            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;
            if (rectangle.ConnectionSiteCount > 4)
            {
                connector.EndShapeConnectionSiteIndex = 4;
            }
            connector.Reroute();
            string outputPath = "CurvedConnectorDemo.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}