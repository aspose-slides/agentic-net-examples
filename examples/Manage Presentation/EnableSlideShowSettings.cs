using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Enable looping of the slide show
        presentation.SlideShowSettings.Loop = true;

        // Enable rehearsal timings for the slide show
        presentation.SlideShowSettings.UseTimings = true;

        // Save the presentation in PPTX format
        presentation.Save("LoopRehearsal.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}