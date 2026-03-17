using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Retrieve a slide by its zero‑based index
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Example usage: output the slide number
            Console.WriteLine("Retrieved slide number: " + slide.SlideNumber);

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}