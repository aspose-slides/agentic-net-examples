using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the shape collection of the first slide
        Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add sample shapes
        Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);
        Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 300, 100, 100);

        // Add connectors between the shapes
        Aspose.Slides.IConnector connector1 = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);
        connector1.StartShapeConnectedTo = ellipse;
        connector1.EndShapeConnectedTo = rectangle;
        connector1.Reroute();

        Aspose.Slides.IConnector connector2 = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 50, 50, 10, 10);
        connector2.StartShapeConnectedTo = rectangle;
        connector2.EndShapeConnectedTo = ellipse;
        connector2.Reroute();

        // Set line join style to Round for all connector shapes
        for (int i = 0; i < shapes.Count; i++)
        {
            Aspose.Slides.IShape shape = shapes[i];
            if (shape is Aspose.Slides.IConnector)
            {
                Aspose.Slides.IConnector connector = (Aspose.Slides.IConnector)shape;
                if (connector.LineFormat != null)
                {
                    connector.LineFormat.JoinStyle = Aspose.Slides.LineJoinStyle.Round;
                }
            }
        }

        // Save the presentation
        string outputPath = "ConnectorsRoundJoinStyle.pptx";
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}