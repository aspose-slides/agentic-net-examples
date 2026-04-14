using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the shapes collection of the first slide
            IShapeCollection shapes = presentation.Slides[0].Shapes;

            // Add a source ellipse shape with solid fill
            IAutoShape sourceShape = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
            sourceShape.FillFormat.FillType = FillType.Solid;
            sourceShape.FillFormat.SolidFillColor.Color = Color.Red;

            // Add a target rectangle shape
            IAutoShape targetShape = shapes.AddAutoShape(ShapeType.Rectangle, 200, 300, 100, 100);
            targetShape.FillFormat.FillType = FillType.Solid;
            targetShape.FillFormat.SolidFillColor.Color = Color.LightGray;

            // Add a straight connector
            IConnector connector = shapes.AddConnector(ShapeType.Line, 0, 0, 10, 10);
            connector.StartShapeConnectedTo = sourceShape;
            connector.EndShapeConnectedTo = targetShape;
            connector.Reroute();

            // Set connector line color based on source shape's fill color
            connector.LineFormat.FillFormat.FillType = FillType.Solid;
            connector.LineFormat.FillFormat.SolidFillColor.Color = sourceShape.FillFormat.SolidFillColor.Color;

            // Save the presentation
            string outputPath = "ConnectorDemo.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}