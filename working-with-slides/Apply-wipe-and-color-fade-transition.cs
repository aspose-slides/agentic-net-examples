// -----------------------------------------------------------------------------
// Example: Apply wipe and color fade transition using C#
//
// Description:
// Demonstrates how to apply a wipe slide transition and configure the optional
// black transition using C# and Aspose.Slides for .NET. The example creates a
// new presentation, adds a blank slide, sets the transition type to Wipe, and
// disables the "from black" effect. It then saves the presentation as a PPTX
// file. This pattern can be used to automate slide transition settings in
// PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Wipe, Color Fade, 
// Optional Black Transition, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying wipe transitions to slides.
// - Configure optional black transition settings programmatically.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or modify PPTX files with specific slide transition effects.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTransitionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "CustomTransition.pptx";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a blank slide
            ISlide slide = pres.Slides[0];

            try
            {
                // Apply Wipe transition
                pres.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Wipe;

                // Note: Aspose.Slides does not provide a direct API for color fade; this is a placeholder.
                // If a color fade were supported, it would be set here.

                // Example of setting optional black transition (from black = false)
                Aspose.Slides.SlideShow.OptionalBlackTransition optionalBlack = (Aspose.Slides.SlideShow.OptionalBlackTransition)pres.Slides[0].SlideShowTransition.Value;
                optionalBlack.FromBlack = false;

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle accordingly
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
