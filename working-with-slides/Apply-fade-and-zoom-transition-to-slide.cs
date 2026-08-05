// -----------------------------------------------------------------------------
// Example: Apply fade and zoom transition to slide using C#
//
// Description:
// Demonstrates how to apply a fade transition to the first slide and a zoom
// frame linking to a second slide using C# and Aspose.Slides for .NET. The
// example creates a new presentation, adds a target slide, inserts a zoom
// frame on the first slide, sets the zoom transition duration, applies a fade
// transition to the first slide, and saves the result as a PPTX file. This
// pattern can be used to automate slide transition effects in PowerPoint
// presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Fade Transition, Zoom Frame,
// Slide Transition, Presentation Automation, Office Automation
//
// Use Cases:
// - Automate adding fade and zoom transitions to PowerPoint slides.
// - Build C# tools for enhancing slide navigation and visual effects.
// - Generate or modify PPTX files with custom transition settings in .NET
//   applications.
// - Validate presentation transition workflows before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

namespace CustomTransitionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "CustomTransition.pptx");

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a second slide to serve as the zoom target
                Aspose.Slides.ISlide targetSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Add a ZoomFrame on the first slide linking to the second slide
                Aspose.Slides.IZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddZoomFrame(150, 20, 50, 50, targetSlide);
                // Set the transition duration for the zoom effect
                zoomFrame.TransitionDuration = 2.0f;

                // Apply a Fade transition to the first slide
                presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
