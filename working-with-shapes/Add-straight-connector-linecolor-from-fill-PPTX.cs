using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string outputPath = "ConnectorDemo.pptx";
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

            // Add source shape with solid fill
            Aspose.Slides.IAutoShape sourceShape = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 150, 100);
            sourceShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            sourceShape.FillFormat.SolidFillColor.Color = Color.Green;

            // Add target shape
            Aspose.Slides.IAutoShape targetShape = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 300, 200, 150, 100);
            targetShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            targetShape.FillFormat.SolidFillColor.Color = Color.LightBlue;

            // Add straight connector
            Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.Line, 0, 0, 10, 10);
            connector.StartShapeConnectedTo = sourceShape;
            connector.EndShapeConnectedTo = targetShape;
            connector.Reroute();

            // Set connector line color based on source shape's fill color
            Color sourceFillColor = sourceShape.FillFormat.SolidFillColor.Color;
            connector.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            connector.LineFormat.FillFormat.SolidFillColor.Color = sourceFillColor;

            // Save presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}