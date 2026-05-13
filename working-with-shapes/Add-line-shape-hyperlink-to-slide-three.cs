using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a second slide to navigate to
        Aspose.Slides.ISlide targetSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Add a line shape on the first slide
        Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

        // Assign internal hyperlink to the target slide
        lineShape.HyperlinkClick = new Aspose.Slides.Hyperlink(targetSlide);
        lineShape.HyperlinkClick.Tooltip = "Go to slide 2";

        // Save the presentation
        presentation.Save("LineHyperlink.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}