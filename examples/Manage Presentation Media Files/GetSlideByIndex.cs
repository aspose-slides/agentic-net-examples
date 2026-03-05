using System;

namespace SlideReferenceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input PPTX file
            string inputPath = "input.pptx";
            // Path to the output PPTX file
            string outputPath = "output.pptx";

            // Load the presentation from the PPTX file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Index of the slide to retrieve (zero-based)
                int slideIndex = 0;

                // Get the slide reference by index
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Example: write slide ID to console
                Console.WriteLine("Slide ID: " + slide.SlideId);

                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}