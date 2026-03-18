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
                // Path to the source presentation
                string sourcePath = "source.pptx";
                // Path to the destination presentation
                string destinationPath = "merged.pptx";

                // Load the source presentation
                using (Presentation sourcePresentation = new Presentation(sourcePath))
                {
                    // Create a new empty presentation
                    using (Presentation destinationPresentation = new Presentation())
                    {
                        // Remove the default empty slide from the destination
                        destinationPresentation.Slides.RemoveAt(0);

                        // Iterate through each slide in the source and clone it into the destination
                        for (int i = 0; i < sourcePresentation.Slides.Count; i++)
                        {
                            ISlide sourceSlide = sourcePresentation.Slides[i];
                            // Insert a clone of the source slide at the end of the destination slides collection
                            destinationPresentation.Slides.InsertClone(destinationPresentation.Slides.Count, sourceSlide);
                        }

                        // Save the merged presentation as PPTX
                        destinationPresentation.Save(destinationPath, SaveFormat.Pptx);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}