using System;
using Aspose.Slides.Export;
using System.Drawing;

namespace ConnectorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the shape collection of the first slide
            Aspose.Slides.IShapeCollection shapes = pres.Slides[0].Shapes;

            // Add a source shape (ellipse) with solid fill
            Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);
            ellipse.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            ellipse.FillFormat.SolidFillColor.Color = Color.Red;

            // Add a target shape (rectangle)
            Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 100, 100, 100);
            rectangle.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            rectangle.FillFormat.SolidFillColor.Color = Color.LightGray;

            // Add a straight connector
            Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.Line, 0, 0, 10, 10);
            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;
            connector.Reroute();

            // Set connector line color based on source shape's fill color
            connector.LineFormat.FillFormat.SolidFillColor.Color = ellipse.FillFormat.SolidFillColor.Color;

            try
            {
                // Save the presentation
                pres.Save("ConnectorDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose the presentation
            pres.Dispose();
        }
    }
}