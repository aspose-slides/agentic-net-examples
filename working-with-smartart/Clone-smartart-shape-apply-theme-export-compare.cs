using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtCloneWithTheme
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "InputPresentation.pptx";
            // Output paths
            string originalOutputPath = "OriginalPresentation.pptx";
            string cloneOutputPath = "CloneWithThemePresentation.pptx";
            // External theme file path (.thmx)
            string themePath = "CustomTheme.thmx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Save the original presentation (without modifications)
            presentation.Save(originalOutputPath, SaveFormat.Pptx);

            // Clone the first slide (which contains the SmartArt)
            ISlideCollection slides = presentation.Slides;
            ISlide sourceSlide = slides[0];
            ISlide clonedSlide = slides.AddClone(sourceSlide);

            // Apply external theme to the master of the cloned slide
            IMasterSlide sourceMaster = clonedSlide.LayoutSlide.MasterSlide;
            IMasterSlide themedMaster = sourceMaster.ApplyExternalThemeToDependingSlides(themePath);
            // Ensure the cloned slide uses the new themed master
            clonedSlide.LayoutSlide.MasterSlide = themedMaster;

            // Save the presentation containing the cloned slide with the applied theme
            presentation.Save(cloneOutputPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}