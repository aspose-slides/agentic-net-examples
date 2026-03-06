using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set the first slide number using a numeric constant
        presentation.FirstSlideNumber = 10;

        // Make slide numbers visible on all slides
        presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

        // Set grid spacing using a numeric constant (points)
        presentation.ViewProperties.GridSpacing = 72f;

        // Set custom slide size using numeric width and height
        presentation.SlideSize.SetSize(960, 540, Aspose.Slides.SlideSizeScaleType.DoNotScale);

        // Save the presentation before exiting
        presentation.Save("NumericalConstantsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}