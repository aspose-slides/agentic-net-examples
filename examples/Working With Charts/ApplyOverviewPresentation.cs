using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set the slide show type to PresentedBySpeaker (overview mode)
        presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.PresentedBySpeaker();

        // Save the presentation
        presentation.Save("OverviewPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}