using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "LineDashStyleDemo.pptx";
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line shape to the slide
            Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

            // Set the line dash style to dash‑dot‑dot
            line.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.LargeDashDotDot;

            // Save the presentation (PowerPoint viewer can render it)
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format or file I/O issues
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}