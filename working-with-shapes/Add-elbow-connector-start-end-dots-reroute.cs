using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectShapesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the shape collection of the first slide
            Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

            // Add an ellipse shape
            Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);

            // Add a rectangle shape
            Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 300, 100, 100);

            // Add a bent connector (elbow connector)
            Aspose.Slides.IConnector connector = shapes.AddConnector(
                Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

            // Connect the shapes
            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;

            // Specify connection sites (dots) if available
            if (ellipse.ConnectionSiteCount > 0)
            {
                connector.StartShapeConnectionSiteIndex = 0;
            }
            if (rectangle.ConnectionSiteCount > 0)
            {
                connector.EndShapeConnectionSiteIndex = 0;
            }

            // Reroute to the shortest path
            connector.Reroute();

            // Save the presentation
            string outputPath = "ConnectedShapes.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}