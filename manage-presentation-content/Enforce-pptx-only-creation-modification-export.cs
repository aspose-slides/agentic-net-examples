using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a new blank slide based on the first slide's layout
        Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Set a simple fade transition for the new slide
        slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;

        // Set the first slide number
        presentation.FirstSlideNumber = 5;

        // Set slide size with EnsureFit scaling
        presentation.SlideSize.SetSize(960f, 540f, Aspose.Slides.SlideSizeScaleType.EnsureFit);

        // Define output file path
        string outputPath = "OutputPresentation.pptx";

        // Save the presentation in PPTX format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}