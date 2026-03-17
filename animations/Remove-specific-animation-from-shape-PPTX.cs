using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the input and output presentation files
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Get the first slide (adjust index as needed)
                ISlide slide = presentation.Slides[0];

                // Locate the target shape by its name or alternative text
                IShape targetShape = SlideUtil.FindShape(slide, "TargetShape");

                if (targetShape != null)
                {
                    // Access the main animation sequence of the slide
                    ISequence mainSequence = slide.Timeline.MainSequence;

                    // Remove all animation effects associated with the target shape
                    mainSequence.RemoveByShape(targetShape);
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}