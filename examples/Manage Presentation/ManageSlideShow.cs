using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load an existing presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Set the slide show type to PresentedBySpeaker (full‑screen mode)
        presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.PresentedBySpeaker();

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}