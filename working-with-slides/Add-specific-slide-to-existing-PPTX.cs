using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideInsertionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the source and destination presentations
            string sourcePath = "source.pptx";
            string destinationPath = "result.pptx";

            try
            {
                // Load the source presentation containing the slide to be copied
                using (Presentation sourcePresentation = new Presentation(sourcePath))
                {
                    // Create a new destination presentation (starts with one empty slide)
                    using (Presentation destinationPresentation = new Presentation())
                    {
                        // Retrieve the specific slide from the source (e.g., first slide)
                        ISlide sourceSlide = sourcePresentation.Slides[0];

                        // Clone the source slide into the destination presentation
                        ISlide clonedSlide = destinationPresentation.Slides.AddClone(sourceSlide);

                        // Optionally, remove the initial empty slide if not needed
                        destinationPresentation.Slides.RemoveAt(0);

                        // Save the modified destination presentation
                        destinationPresentation.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}