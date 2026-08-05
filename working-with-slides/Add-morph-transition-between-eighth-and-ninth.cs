// -----------------------------------------------------------------------------
// Example: Add morph transition between eighth and ninth using C#
//
// Description:
// Demonstrates how to add a Morph transition between the eighth and ninth slides
// in a PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// creates a new presentation, clones slides to ensure nine slides exist, applies
// a Morph transition with a custom MorphType, and saves the result as a PPTX file.
// This pattern can be used to automate slide transitions in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Morph, Transition, Slide, 
// Eighth, Ninth, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a Morph transition between specific slides.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or modify PPTX files with custom transitions in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Ensure there is at least one slide to clone from
        var baseSlide = presentation.Slides[0];

        // Add slides up to slide nine (indices 0‑8)
        for (int i = 1; i < 9; i++)
        {
            presentation.Slides.AddClone(baseSlide);
        }

        // Apply Morph transition between slide eight (index 7) and slide nine (index 8)
        // Set the transition type to Morph
        presentation.Slides[7].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

        // Cast the transition value to MorphTransition to set a custom MorphType
        var morphTransition = (Aspose.Slides.SlideShow.MorphTransition)presentation.Slides[7].SlideShowTransition.Value;
        morphTransition.MorphType = Aspose.Slides.SlideShow.TransitionMorphType.ByWord; // Custom morph type

        // Save the presentation
        presentation.Save("MorphTransitionExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
