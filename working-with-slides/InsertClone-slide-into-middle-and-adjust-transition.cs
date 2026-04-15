using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideCloneDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Clone the second slide (index 1) into the middle position (index 2)
                ISlide sourceSlide = pres.Slides[1];
                ISlide clonedSlide = pres.Slides.InsertClone(2, sourceSlide);

                // Adjust transition timing for the cloned slide
                clonedSlide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                clonedSlide.SlideShowTransition.AdvanceOnClick = true;
                clonedSlide.SlideShowTransition.AdvanceAfterTime = 4000; // 4 seconds

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // If the exception is due to an unsupported format, handle accordingly
                // (In a real scenario, check the exception type or message)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}