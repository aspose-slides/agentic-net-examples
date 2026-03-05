using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("AccessSlides.pptx");

        // Iterate through each slide and read its transition settings
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlideShowTransition transition = presentation.Slides[i].SlideShowTransition;

            // Output transition details to the console
            Console.WriteLine("Slide " + (i + 1) + " Transition Type: " + transition.Type);
            Console.WriteLine("Duration (ms): " + transition.Duration);
            Console.WriteLine("Advance On Click: " + transition.AdvanceOnClick);
            Console.WriteLine("Advance After Time (ms): " + transition.AdvanceAfterTime);
            Console.WriteLine();
        }

        // Save the presentation before exiting
        presentation.Save("AccessSlides_TransitionInfo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}