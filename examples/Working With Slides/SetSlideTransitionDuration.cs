using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Configure the transition duration for the first slide (2000 milliseconds)
        presentation.Slides[0].SlideShowTransition.Duration = 2000;

        // Save the presentation to disk
        presentation.Save("TransitionDuration_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}