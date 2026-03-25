using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

class Program
{
    static void Main()
    {
        // Logical constants controlling content
        const string inputPath = "input.pptx";
        const string outputPath = "output.pptx";
        const bool useCustomBackground = true;
        const Aspose.Slides.FillType backgroundFill = Aspose.Slides.FillType.Solid;
        const Aspose.Slides.SlideShow.TransitionType transitionType = Aspose.Slides.SlideShow.TransitionType.Fade;
        const uint transitionTime = 4000; // milliseconds

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Apply conditional background to the first slide
            if (useCustomBackground)
            {
                // Retrieve effective background data (read‑only)
                Aspose.Slides.IBackgroundEffectiveData bgData = presentation.Slides[0].Background.GetEffective();

                // Force solid fill and set color
                presentation.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                presentation.Slides[0].Background.FillFormat.FillType = backgroundFill;
                presentation.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.Blue;
            }

            // Set slide transition based on constants
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
            firstSlide.SlideShowTransition.Type = transitionType;
            firstSlide.SlideShowTransition.AdvanceAfter = true;
            firstSlide.SlideShowTransition.AdvanceAfterTime = transitionTime;

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}