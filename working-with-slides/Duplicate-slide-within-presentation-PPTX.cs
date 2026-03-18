using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideCopyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Get the slide collection
                Aspose.Slides.ISlideCollection slides = presentation.Slides;

                // Clone the first slide and insert it at the end of the collection
                Aspose.Slides.ISlide clonedSlide = slides.InsertClone(slides.Count, slides[0]);

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}