using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            var pres = new Aspose.Slides.Presentation(inputPath);
            // Clone slide at index 1 to position 2 (middle of deck)
            var sourceSlide = pres.Slides[1];
            var clonedSlide = pres.Slides.InsertClone(2, sourceSlide);
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
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}