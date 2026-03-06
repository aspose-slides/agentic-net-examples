using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main(string[] args)
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Enable the use of timings in the slide show
        presentation.SlideShowSettings.UseTimings = true;

        // Set a default delay for generated animations (in milliseconds)
        Aspose.Slides.Export.PresentationAnimationsGenerator animationsGenerator =
            new Aspose.Slides.Export.PresentationAnimationsGenerator(presentation.SlideSize.Size.ToSize());
        animationsGenerator.DefaultDelay = 500; // 0.5 seconds

        // Configure slide transition duration for the first slide (in milliseconds)
        Aspose.Slides.ISlideShowTransition transition = presentation.Slides[0].SlideShowTransition;
        transition.Duration = 2000; // 2 seconds

        // Generate animation events (optional, demonstrates usage)
        animationsGenerator.Run(presentation.Slides);

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        animationsGenerator.Dispose();
        presentation.Dispose();
    }
}