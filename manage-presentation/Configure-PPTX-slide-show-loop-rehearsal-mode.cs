using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Configure slide show settings: loop continuously
            Aspose.Slides.SlideShowSettings slideShowSettings = presentation.SlideShowSettings;
            slideShowSettings.Loop = true;
            // Activate rehearsal mode (use timings)
            slideShowSettings.UseTimings = true;

            // Save the presentation before exiting
            presentation.Save("RehearsalLoop.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}