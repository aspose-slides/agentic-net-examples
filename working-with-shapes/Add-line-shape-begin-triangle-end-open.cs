using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

        // Set the begin arrow style to Triangle and end arrow style to Open
        line.LineFormat.BeginArrowheadStyle = Aspose.Slides.LineArrowheadStyle.Triangle;
        line.LineFormat.EndArrowheadStyle = Aspose.Slides.LineArrowheadStyle.Open;

        // Save the presentation
        string outputPath = "ArrowLine.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}