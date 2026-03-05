using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the collection of slides
        Aspose.Slides.ISlideCollection slides = presentation.Slides;

        // Output the total number of slides
        Console.WriteLine("Total slides: " + slides.Count);

        // Iterate through each slide and display its index
        for (int i = 0; i < slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = slides[i];
            Console.WriteLine("Slide index: " + i);
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}