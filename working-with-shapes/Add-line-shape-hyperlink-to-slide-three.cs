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

        // Get the first slide
        Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

        // Add a line shape on the first slide
        Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)firstSlide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Line, 50, 100, 300, 0);

        // Create a hyperlink that points to the second slide
        Aspose.Slides.Hyperlink slideHyperlink = new Aspose.Slides.Hyperlink(targetSlide);

        // Assign the hyperlink to the line shape
        lineShape.HyperlinkClick = slideHyperlink;

        // Save the presentation
        try
        {
            presentation.Save("LineHyperlink.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
        finally
        {
            // Dispose the presentation
            presentation.Dispose();
        }
    }
}