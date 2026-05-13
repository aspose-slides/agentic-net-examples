using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Get the shape collection of the slide
        IShapeCollection shapes = slide.Shapes;

        // Add a straight connector (using BentConnector2 as a straight line)
        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 100, 100, 200, 0);

        // Set the line dash style to long dash dot
        connector.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.LargeDashDot;

        // Save the presentation
        string outputPath = "ConnectorDemo.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}