using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideReorderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Get the slide to move (first slide)
                ISlide slideToMove = pres.Slides[0];

                // Target index (zero‑based). Move the slide to position 2 (third slide)
                int targetIndex = 2;

                // Reorder the slide within the collection
                pres.Slides.Reorder(targetIndex, slideToMove);

                // Verify the new index of the moved slide
                int newIndex = pres.Slides.IndexOf(slideToMove);
                Console.WriteLine("Slide moved to new index: " + newIndex);

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario here
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}