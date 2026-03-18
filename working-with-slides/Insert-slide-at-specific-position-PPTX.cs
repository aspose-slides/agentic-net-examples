using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertSlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";
            // Path to the output presentation
            string outputPath = "output.pptx";
            // Zero‑based index where the new slide will be inserted
            int insertIndex = 2;

            try
            {
                // Load the existing presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
                {
                    // Get a layout slide to use for the new empty slide
                    Aspose.Slides.ILayoutSlide layoutSlide = presentation.LayoutSlides[0];

                    // Insert a new empty slide at the specified position
                    presentation.Slides.InsertEmptySlide(insertIndex, layoutSlide);

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}