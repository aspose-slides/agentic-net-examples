using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IShapeCollection shapes = slide.Shapes;

            // Add a curved connector to the slide
            Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.CurvedConnector2, 50, 150, 300, 0);

            // Set the line width to three points
            connector.LineFormat.Width = 3;

            // Verify visual thickness (property check; actual visual verification is manual)
            // System.Console.WriteLine("Connector line width: " + connector.LineFormat.Width);

            // Save the presentation
            string outputPath = "CurvedConnector.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, file I/O errors)
        }
    }
}