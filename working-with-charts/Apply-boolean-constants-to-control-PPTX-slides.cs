using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideBehaviorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Logical constants controlling slide behavior
            bool enableAutoAdvance = true;
            bool enableMediaControls = true;

            // Load existing presentation if it exists; otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            // Apply slide transition settings based on logical constants
            if (enableAutoAdvance)
            {
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    presentation.Slides[i].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                    presentation.Slides[i].SlideShowTransition.AdvanceOnClick = true;
                    presentation.Slides[i].SlideShowTransition.AdvanceAfter = true;
                    presentation.Slides[i].SlideShowTransition.AdvanceAfterTime = 5000; // 5 seconds
                }
            }

            // Set media controls visibility
            presentation.SlideShowSettings.ShowMediaControls = enableMediaControls;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}