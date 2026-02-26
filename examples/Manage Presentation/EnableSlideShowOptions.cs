using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Enable media controls in slide show settings
        presentation.SlideShowSettings.ShowMediaControls = true;

        // Save the presentation to a PPTX file
        string outputPath = "EnableSlideShowOptions_out.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}