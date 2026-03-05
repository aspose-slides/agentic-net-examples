using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Retrieve the collection of all slides
            Aspose.Slides.ISlideCollection slides = presentation.Slides;

            // Iterate through each slide and output its index
            for (int i = 0; i < slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = slides[i];
                Console.WriteLine("Slide index: " + i);
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}