using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TransferSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the source and destination presentations
            string sourcePath = "source.pptx";
            string destinationPath = "destination.pptx";

            // Load the source presentation
            using (Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Create a new empty destination presentation
                using (Aspose.Slides.Presentation destinationPresentation = new Aspose.Slides.Presentation())
                {
                    // Iterate through each slide in the source presentation
                    for (int index = 0; index < sourcePresentation.Slides.Count; index++)
                    {
                        // Get the current slide
                        Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[index];

                        // Clone the slide into the destination presentation
                        destinationPresentation.Slides.AddClone(sourceSlide);
                    }

                    // Save the destination presentation before exiting
                    destinationPresentation.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }
    }
}