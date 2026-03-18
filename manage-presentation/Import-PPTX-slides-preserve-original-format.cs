using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideImportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to the source and destination presentations
                string sourcePath = "SourcePresentation.pptx";
                string destinationPath = "CombinedPresentation.pptx";

                // Load the source presentation
                using (Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(sourcePath))
                // Create a new destination presentation
                using (Aspose.Slides.Presentation destinationPresentation = new Aspose.Slides.Presentation())
                {
                    Aspose.Slides.ISlideCollection destinationSlides = destinationPresentation.Slides;

                    // Clone each slide from the source into the destination, preserving layout and formatting
                    for (int i = 0; i < sourcePresentation.Slides.Count; i++)
                    {
                        Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[i];
                        destinationSlides.InsertClone(destinationSlides.Count, sourceSlide);
                    }

                    // Save the combined presentation
                    destinationPresentation.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}