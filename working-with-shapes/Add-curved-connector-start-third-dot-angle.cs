using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "CurvedConnector.pptx";
        using (Presentation presentation = new Presentation())
        {
            IShapeCollection shapes = presentation.Slides[0].Shapes;
            IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
            IConnector connector = shapes.AddConnector(ShapeType.CurvedConnector2, 0, 0, 100, 0);
            connector.StartShapeConnectedTo = ellipse;
            if (ellipse.ConnectionSiteCount > 2)
            {
                connector.StartShapeConnectionSiteIndex = 2;
            }
            connector.Reroute();
            double angle = GetDirection(connector.Width, connector.Height,
                Convert.ToBoolean(connector.Frame.FlipH), Convert.ToBoolean(connector.Frame.FlipV));
            Console.WriteLine("Connector line angle: " + angle);
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }

    private static double GetDirection(float width, float height, bool flipH, bool flipV)
    {
        double w = flipH ? -width : width;
        double h = flipV ? -height : height;
        double radians = Math.Atan2(h, w);
        double degrees = radians * (180.0 / Math.PI);
        return degrees;
    }
}