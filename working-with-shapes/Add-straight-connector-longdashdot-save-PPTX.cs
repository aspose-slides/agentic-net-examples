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
        // Add a straight connector to the slide
        IConnector connector = slide.Shapes.AddConnector(ShapeType.Line, 100f, 100f, 300f, 0f);
        // Set the connector's line dash style to long dash dot
        connector.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.LargeDashDot;
        // Define output file path
        string outputPath = "ConnectorDemo.pptx";
        // Save the presentation with exception handling for unsupported formats
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}