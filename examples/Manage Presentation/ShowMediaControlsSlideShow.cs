using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Enable media controls during slide show
        presentation.SlideShowSettings.ShowMediaControls = true;

        // Save the presentation to a file
        presentation.Save("MediaControlsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}