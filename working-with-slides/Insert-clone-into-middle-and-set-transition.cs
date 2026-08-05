// -----------------------------------------------------------------------------
// Example: Insert clone into middle and set transition using C#
//
// Description:
// Demonstrates how to insert a cloned slide into the middle of a presentation
// and configure its slide show transition using Aspose.Slides for .NET. The
// example loads an existing PPTX file, clones a slide, sets a fade transition
// with a 4‑second advance time, and saves the result as a new PPTX file.
// This pattern can be used to automate slide duplication and transition
// customization in PowerPoint automation scenarios.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert Clone, Middle Slide,
// Transition, SlideShowTransition, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning a slide into a specific position and applying a transition.
// - Build .NET tools for PowerPoint slide manipulation and presentation flow control.
// - Generate or modify PPTX files with custom slide timings in batch processes.
// - Validate and preview presentation changes before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            var pres = new Presentation(inputPath);
            // Clone slide at index 1 to position 2 (middle of deck)
            var sourceSlide = pres.Slides[1];
            var clonedSlide = pres.Slides.InsertClone(2, sourceSlide);
            // Adjust transition timing for the cloned slide
            clonedSlide.SlideShowTransition.Type = SlideShow.TransitionType.Fade;
            clonedSlide.SlideShowTransition.AdvanceOnClick = true;
            clonedSlide.SlideShowTransition.AdvanceAfterTime = 4000; // 4 seconds
            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
