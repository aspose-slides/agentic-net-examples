using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideImportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to source and destination presentations
            string sourcePath = "source.pptx";
            string destinationPath = "merged.pptx";

            // Load the source presentation
            using (Presentation sourcePresentation = new Presentation(sourcePath))
            {
                // Create a new empty presentation
                using (Presentation destinationPresentation = new Presentation())
                {
                    // Remove the default empty slide from the new presentation
                    destinationPresentation.Slides.RemoveAt(0);

                    // Import each slide from the source while preserving formatting
                    for (int index = 0; index < sourcePresentation.Slides.Count; index++)
                    {
                        ISlide sourceSlide = sourcePresentation.Slides[index];
                        // Insert a clone of the source slide at the end of the destination slides collection
                        destinationPresentation.Slides.InsertClone(destinationPresentation.Slides.Count, sourceSlide);
                    }

                    // Save the merged presentation
                    destinationPresentation.Save(destinationPath, SaveFormat.Pptx);
                }
            }
        }
    }
}