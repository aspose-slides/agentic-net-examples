// -----------------------------------------------------------------------------
// Example: Configure slide transition fade two seconds using C#
//
// Description:
// Demonstrates how to configure a Fade slide transition with a duration of two
// seconds for each slide in a PowerPoint presentation using Aspose.Slides for
// .NET. The example creates a presentation, ensures a minimum number of slides,
// applies the transition settings, and saves the result as a PPTX file. This
// pattern can be used to automate slide transition configuration in .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Slide, Transition,
// Fade, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate the configuration of a Fade transition lasting two seconds on all
//   slides.
// - Build C# tools for PowerPoint presentation processing that include custom
//   slide transitions.
// - Generate or modify PPTX files with specific transition effects in .NET
//   applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTransitionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Ensure there are at least three slides for demonstration
            while (presentation.Slides.Count < 3)
            {
                presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Apply Fade transition with a duration of 2 seconds (2000 ms) to each slide
            foreach (ISlide slide in presentation.Slides)
            {
                slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                slide.SlideShowTransition.Duration = 2000; // duration in milliseconds
            }

            // Define output file path
            string outputPath = "SlideTransitionDemo.pptx";

            try
            {
                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., format not supported)
                // Format not supported
            }
            finally
            {
                // Dispose the presentation
                presentation.Dispose();
            }
        }
    }
}
