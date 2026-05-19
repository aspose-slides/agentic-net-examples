using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace ValidateSmartArtHidden
{
    class Program
    {
        static void Main()
        {
            // Input files
            string presentationPath = "input.pptx";
            string themePath = "theme.thmx";
            // Expected visibility after applying the theme
            bool expectedHidden = false;

            // Verify that the presentation file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            // Verify that the theme file exists
            if (!File.Exists(themePath))
            {
                Console.WriteLine("Theme file not found: " + themePath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(presentationPath))
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram to the slide
                Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                    0f, 0f, 400f, 300f, SmartArtLayoutType.BasicBlockList);

                // Set initial Hidden property
                smartArt.Hidden = false;

                // Apply external theme to the first master slide
                try
                {
                    Aspose.Slides.IMasterSlide master = presentation.Masters[0];
                    master.ApplyExternalThemeToDependingSlides(themePath);
                }
                catch (Exception ex)
                {
                    // Handle exceptions related to applying the external theme
                    Console.WriteLine("Error applying theme: " + ex.Message);
                    // Continue execution; the theme may not affect the Hidden property
                }

                // Validate the Hidden property after theme application
                bool actualHidden = smartArt.Hidden;
                if (actualHidden == expectedHidden)
                {
                    Console.WriteLine("Validation succeeded: Hidden property matches expected value.");
                }
                else
                {
                    Console.WriteLine("Validation failed: Expected Hidden = " + expectedHidden +
                                      ", but actual Hidden = " + actualHidden);
                }

                // Save the presentation before exiting
                string outputPath = "output.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
        }
    }
}