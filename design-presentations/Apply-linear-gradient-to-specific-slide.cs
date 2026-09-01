// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply linear gradient to specific slide using C#

//

// Description:

// Demonstrates how to apply a linear gradient background to a specific slide 

// using C# and Aspose.Slides for .NET. The example creates a presentation, 

// configures the first slide's background with a custom gradient, and saves 

// the result as a PPTX file. This pattern can be used to automate PowerPoint 

// slide styling in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Linear, Gradient, 

// Specific, Slide, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate applying a linear gradient background to a specific slide.

// - Build C# tools for PowerPoint presentation styling.

// - Generate or transform PPTX files with custom slide backgrounds in .NET.

// - Validate slide design workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Create a new presentation

        Presentation presentation = new Presentation();



        // Access the first slide

        ISlide slide = presentation.Slides[0];



        // Set the slide background to a gradient

        slide.Background.Type = BackgroundType.OwnBackground;

        slide.Background.FillFormat.FillType = FillType.Gradient;



        // Set a custom gradient angle (in degrees)

        slide.Background.FillFormat.GradientFormat.LinearGradientAngle = 45f;



        // Define gradient colors

        slide.Background.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Purple);

        slide.Background.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Red);



        // Save the presentation

        string outputPath = "GradientBackground.pptx";

        presentation.Save(outputPath, SaveFormat.Pptx);

    }

}

