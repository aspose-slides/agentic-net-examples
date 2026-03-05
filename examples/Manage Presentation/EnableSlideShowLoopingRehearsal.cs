using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Enable looping of the slide show
        presentation.SlideShowSettings.Loop = true;

        // Enable rehearsal mode by using slide timings
        presentation.SlideShowSettings.UseTimings = true;

        // Show media controls during the slide show (optional)
        presentation.SlideShowSettings.ShowMediaControls = true;

        // Save the presentation in PPTX format
        string outputPath = "EnableLoopRehearsal.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}