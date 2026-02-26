using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneMultipleSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the source presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("source.pptx"))
            {
                // Get the slide collection
                Aspose.Slides.ISlideCollection slides = pres.Slides;

                // Define the range of slides to clone (e.g., first three slides)
                int startIndex = 0;
                int endIndex = 2; // inclusive

                // Loop through the specified range and clone each slide to the end of the collection
                for (int i = startIndex; i <= endIndex; i++)
                {
                    // Clone the slide and add it to the end of the collection
                    slides.AddClone(slides[i]);
                }

                // Save the modified presentation
                pres.Save("cloned_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}