using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

class Program
{
    static void Main()
    {
        // Paths to the input and output PPTX files
        string inputPath = "InputPresentation.pptx";
        string outputPath = "OutputPresentation.pptx";

        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Apply a Circle transition to slide 0
        presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Circle;
        presentation.Slides[0].SlideShowTransition.AdvanceOnClick = true;
        presentation.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000u;

        // Apply a Comb transition to slide 1
        presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Comb;
        presentation.Slides[1].SlideShowTransition.AdvanceOnClick = true;
        presentation.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000u;

        // Apply a Zoom transition to slide 2
        presentation.Slides[2].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Zoom;
        presentation.Slides[2].SlideShowTransition.AdvanceOnClick = true;
        presentation.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000u;

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}