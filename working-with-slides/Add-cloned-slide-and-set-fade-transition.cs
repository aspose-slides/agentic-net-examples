using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the source presentation
            Presentation pres = new Presentation(inputPath);

            // Clone the first slide and add it to the end of the collection
            ISlide sourceSlide = pres.Slides[0];
            ISlide clonedSlide = pres.Slides.AddClone(sourceSlide);

            // Change the transition effect of the cloned slide to Fade
            clonedSlide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            clonedSlide.SlideShowTransition.AdvanceOnClick = true;

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}