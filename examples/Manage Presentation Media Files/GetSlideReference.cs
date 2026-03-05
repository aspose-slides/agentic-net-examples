using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get a reference to the slide at the specified index (e.g., first slide)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Example usage: output the slide's ID
        Console.WriteLine("Slide ID: " + slide.SlideId);

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}