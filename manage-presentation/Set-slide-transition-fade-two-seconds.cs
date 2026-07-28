// -----------------------------------------------------------------------------
// Example: Set slide transition fade two seconds using C#
//
// Description:
// Demonstrates how to set a slide transition to Fade with a duration of two
// seconds using C# and Aspose.Slides for .NET. The example creates a new
// presentation, configures the transition on the first slide, and saves the
// result as a PPTX file. This pattern can be used to automate PowerPoint
// presentation workflows, apply consistent slide effects, or integrate
// presentation processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide, Transition, Fade,
// Seconds, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting a fade transition of two seconds on slides.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with specific slide effects in .NET.
// - Validate presentation workflows before publishing or integration.
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
            string outputPath = "FadeTransition.pptx";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Set transition type to Fade
            pres.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;

            // Set transition duration to 2000 milliseconds (2 seconds)
            pres.Slides[0].SlideShowTransition.Duration = 2000;

            try
            {
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                // Format not supported
            }
            finally
            {
                pres.Dispose();
            }
        }
    }
}
