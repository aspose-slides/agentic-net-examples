using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideReorderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // IDs of slides (example values)
            uint slideIdToMove = 3;
            uint targetSlideId = 5;

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Retrieve slides by their IDs
                IBaseSlide baseSlideToMove = pres.GetSlideById(slideIdToMove);
                IBaseSlide baseTargetSlide = pres.GetSlideById(targetSlideId);

                // Cast to ISlide
                ISlide slideToMove = baseSlideToMove as ISlide;
                ISlide targetSlide = baseTargetSlide as ISlide;

                if (slideToMove == null || targetSlide == null)
                {
                    Console.WriteLine("One of the specified IDs does not correspond to a regular slide.");
                    pres.Dispose();
                    return;
                }

                // Determine the index after which the slide should be placed
                int targetIndex = pres.Slides.IndexOf(targetSlide);

                // Move the slide to the new position
                pres.Slides.Reorder(targetIndex + 1, slideToMove);

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}