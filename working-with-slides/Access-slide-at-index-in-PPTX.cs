using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideAccessExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load an existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Access the slide at zero‑based index 1 (second slide)
                Aspose.Slides.ISlide slide = presentation.Slides[1];

                // Example operation: display the slide number
                Console.WriteLine("Accessed slide number: " + slide.SlideNumber);

                // Save the presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}