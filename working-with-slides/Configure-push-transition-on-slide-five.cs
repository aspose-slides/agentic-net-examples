// -----------------------------------------------------------------------------
// Example: Configure push transition on slide five using C#
//
// Description:
// Demonstrates how to configure a push slide transition on the fifth slide of a
// presentation using C# and Aspose.Slides for .NET. The example creates a new
// presentation, ensures it contains at least five slides, applies a push
// transition with a 3‑second automatic advance, and saves the result as a PPTX
// file. This pattern can be used to automate slide‑show effects in .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Push, Transition,
// Slide, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding push transitions to specific slides.
// - Build C# utilities for PowerPoint slide‑show customization.
// - Generate or modify PPTX files with predefined transition effects.
// - Validate slide transition settings before publishing presentations.
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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Ensure there are at least five slides
            while (presentation.Slides.Count < 5)
            {
                // Add an empty slide using the layout of the first slide
                presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Configure Push transition on slide five (index 4)
            presentation.Slides[4].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Push;
            presentation.Slides[4].SlideShowTransition.AdvanceOnClick = true;
            presentation.Slides[4].SlideShowTransition.AdvanceAfterTime = 3000U; // 3 seconds

            // Save the presentation
            string outputPath = "PushTransitionSlide5.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}
