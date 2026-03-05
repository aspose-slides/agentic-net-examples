using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation with a default empty slide
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Iterate through all slides in the presentation
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            // Get the current slide
            Aspose.Slides.ISlide slide = presentation.Slides[i];

            // Set the background to own background and remove any fill (no fill)
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
        }

        // Save the modified presentation to a file
        presentation.Save("RemovedBackground.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}