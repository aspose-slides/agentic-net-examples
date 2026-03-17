using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source presentation
            var sourcePath = "input.pptx";

            // Load the presentation
            using (var presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Zero‑based index of the slide to obtain
                var slideIndex = 0;

                // Retrieve the slide as an ISlide instance
                var slide = presentation.Slides[slideIndex];

                // Example usage: output the slide number
                Console.WriteLine("Obtained slide number: " + slide.SlideNumber);

                // Save the presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}