// -----------------------------------------------------------------------------
// Example: Set slide timing five seconds using C#
//
// Description:
// Demonstrates how to create a presentation, add empty slides based on layout
// slides, configure each slide to advance automatically after five seconds with
// a Fade transition, enable slide show timings, and save the result as a PPTX
// file using Aspose.Slides for .NET. This pattern can be used to automate slide
// timing configuration in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide, Timing, Five, Seconds,
// Presentation, Transition, Fade, Automation
//
// Use Cases:
// - Programmatically set a uniform slide advance interval of five seconds.
// - Add slides dynamically based on existing layouts.
// - Apply consistent transition effects across all slides.
// - Generate or modify PPTX files in .NET applications with automated timings.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTimingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add empty slides based on available layout slides
            Aspose.Slides.ISlideCollection slideColl = pres.Slides;
            for (int i = 0; i < pres.LayoutSlides.Count; i++)
            {
                slideColl.AddEmptySlide(pres.LayoutSlides[i]);
            }

            // Set each slide to advance automatically after 5 seconds (5000 ms)
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                // Choose a transition type (e.g., Fade)
                pres.Slides[i].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                // Enable advance on click (optional)
                pres.Slides[i].SlideShowTransition.AdvanceOnClick = true;
                // Enable automatic advance after specified time
                pres.Slides[i].SlideShowTransition.AdvanceAfter = true;
                pres.Slides[i].SlideShowTransition.AdvanceAfterTime = 5000; // 5 seconds
            }

            // Ensure the slide show uses timings
            pres.SlideShowSettings.UseTimings = true;

            // Define output path
            string outPath = Path.Combine(Environment.CurrentDirectory, "AutomatedPresentation.pptx");

            // Save the presentation
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            pres.Dispose();
        }
    }
}
