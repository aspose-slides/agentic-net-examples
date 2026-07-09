using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Configure arrowheads: no begin arrow, diamond end arrow
        line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
        line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Diamond;

        // Save the presentation
        string outputPath = "LineWithDiamondArrow.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}