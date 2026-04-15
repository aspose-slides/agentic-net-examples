using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load existing presentation if the file exists; otherwise create a new one
        Presentation presentation;
        if (File.Exists(inputPath))
        {
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception)
            {
                // Format not supported
                return;
            }
        }
        else
        {
            presentation = new Presentation();
        }

        // Ensure there is at least one slide to clone
        if (presentation.Slides.Count == 0)
        {
            // Add a blank slide using the first layout slide
            presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        }

        // Insert a clone of the first slide at position 1 (second slide)
        Aspose.Slides.ISlide newSlide = presentation.Slides.InsertClone(1, presentation.Slides[0]);

        // Apply a custom transition effect to the newly inserted slide
        newSlide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
        newSlide.SlideShowTransition.AdvanceOnClick = true;
        newSlide.SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}