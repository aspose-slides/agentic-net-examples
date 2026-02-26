using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Create GIF export options (optional customization)
        Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();

        // Save the presentation as an animated GIF
        presentation.Save("output.gif", Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

        // Release resources
        presentation.Dispose();
    }
}