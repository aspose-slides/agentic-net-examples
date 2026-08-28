// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add slide transitions using C#

//

// Description:

// Demonstrates how to add slide transitions to a PowerPoint presentation using

// C# and Aspose.Slides for .NET. The example creates a new presentation, clones

// the first slide to generate additional slides, applies different transition

// types and timing settings to each slide, and saves the result as a PPTX file.

// This pattern can be used to automate slide transition configuration in .NET

// applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide, Transitions, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate the addition of slide transitions to presentations.

// - Build C# tools for PowerPoint presentation enhancement.

// - Generate or modify PPTX files with custom slide transitions in .NET applications.

// - Prepare presentations with predefined transition effects before distribution.

// -----------------------------------------------------------------------------

using System;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        try

        {

            // Create a new presentation

            Presentation presentation = new Presentation();



            // Add two more slides by cloning the first slide

            presentation.Slides.AddClone(presentation.Slides[0]);

            presentation.Slides.AddClone(presentation.Slides[0]);



            // Set transition for slide 1

            presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Circle;

            presentation.Slides[0].SlideShowTransition.AdvanceOnClick = true;

            presentation.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds



            // Set transition for slide 2

            presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Comb;

            presentation.Slides[1].SlideShowTransition.AdvanceOnClick = true;

            presentation.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000; // 5 seconds



            // Set transition for slide 3

            presentation.Slides[2].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Zoom;

            presentation.Slides[2].SlideShowTransition.AdvanceOnClick = true;

            presentation.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000; // 7 seconds



            // Save the presentation

            presentation.Save("SlideTransitions.pptx", SaveFormat.Pptx);

        }

        catch (Exception ex)

        {

            // Handle exceptions (e.g., unsupported format, I/O errors)

            // Format not supported: comment if needed

        }

    }

}

