using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "ArrowLine.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a line shape to the slide
        IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Set the begin arrow style to Triangle
        line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Triangle;

        // Set the end arrow style to Open
        line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Open;

        // Save the presentation
        pres.Save(outputPath, SaveFormat.Pptx);

        // Clean up
        pres.Dispose();
    }
}