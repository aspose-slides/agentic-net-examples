// -----------------------------------------------------------------------------
// Example: Validate SmartArt shape hidden after applying external theme using C#
//
// Description:
// Demonstrates how to add a SmartArt diagram to a slide, apply an external
// .thmx theme to the presentation's master slide, and verify that the SmartArt's
// Hidden property matches the expected value after the theme is applied.
// The example includes loading a presentation, theme application, property
// validation, and saving the modified file as a standalone console application.
// Developers can use this pattern to automate PPTX workflows, ensure SmartArt
// visibility consistency across themes, or integrate presentation logic into
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Hidden property,
// External theme, Master slide, Presentation processing, Office Automation
//
// Use Cases:
// - Verify SmartArt visibility after applying an external theme.
// - Build C# tools for PowerPoint presentation processing and validation.
// - Ensure presentation styling changes do not unintentionally hide SmartArt.
// - Integrate SmartArt property checks into CI pipelines or automated workflows.
// -----------------------------------------------------------------------------
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
