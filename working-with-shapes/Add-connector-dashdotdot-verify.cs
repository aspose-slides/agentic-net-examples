using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var shapes = presentation.Slides[0].Shapes;
            var ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);
            var rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 300, 100, 100);
            var connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);
            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;
            connector.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.LargeDashDotDot;
            connector.Reroute();
            var outputPath = "ConnectorDashDotDot.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine("Presentation saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}