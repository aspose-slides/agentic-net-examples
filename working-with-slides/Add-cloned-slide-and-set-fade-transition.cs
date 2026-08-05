// -----------------------------------------------------------------------------
// Example: Add cloned slide and set fade transition using C#
//
// Description:
// Demonstrates how to add a cloned slide to a presentation and set a fade
// transition on the cloned slide using C# and Aspose.Slides for .NET. The
// example loads an existing PPTX file, clones the first slide, applies a fade
// transition, and saves the result as a new PPTX file. This pattern can be used
// to automate slide duplication and transition configuration in PowerPoint
// files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Slide, Fade Transition,
// SlideShowTransition, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of slides and applying fade transitions.
// - Build C# utilities for PowerPoint slide manipulation.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate and test presentation workflows before deployment.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the source presentation
            Presentation pres = new Presentation(inputPath);

            // Clone the first slide and add it to the end of the collection
            ISlide sourceSlide = pres.Slides[0];
            ISlide clonedSlide = pres.Slides.AddClone(sourceSlide);

            // Change the transition effect of the cloned slide to Fade
            clonedSlide.SlideShowTransition.Type = SlideShow.TransitionType.Fade;
            clonedSlide.SlideShowTransition.AdvanceOnClick = true;

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
