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
        Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 300, 100, 100);

        // Add a connector between the shapes
        Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;
        connector.Reroute();

        // Set line join style to round for all connectors in the slide
        for (int i = 0; i < shapes.Count; i++)
        {
            Aspose.Slides.IShape shape = shapes[i];
            if (shape is Aspose.Slides.IConnector)
            {
                Aspose.Slides.IConnector conn = (Aspose.Slides.IConnector)shape;
                conn.LineFormat.JoinStyle = Aspose.Slides.LineJoinStyle.Round;
            }
        }

        // Save the presentation
        string outputPath = "ConnectorsRoundJoinStyle.pptx";
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle exceptions such as unsupported format
        }
    }
}