using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneMultipleSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to source and destination presentations
            string sourcePath = "source.pptx";
            string destinationPath = "cloned.pptx";

            // Load the source presentation
            using (Presentation srcPres = new Presentation(sourcePath))
            {
                // Create a new destination presentation
                using (Presentation destPres = new Presentation())
                {
                    // Get the slide collection of the destination presentation
                    ISlideCollection destSlides = destPres.Slides;

                    // Iterate through each slide in the source presentation
                    for (int i = 0; i < srcPres.Slides.Count; i++)
                    {
                        // Get the current source slide
                        ISlide sourceSlide = srcPres.Slides[i];

                        // Insert a clone of the source slide at the end of the destination collection
                        destSlides.InsertClone(destSlides.Count, sourceSlide);
                    }

                    // Save the destination presentation
                    destPres.Save(destinationPath, SaveFormat.Pptx);
                }
            }
        }
    }
}