// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set PPTX slide size to widescreen and change background using C#

//

// Description:

// Demonstrates how to create a new presentation, set its slide size to

// widescreen 16:9 with EnsureFit scaling, modify the first slide's background

// color to blue, and save the result as a PPTX file using Aspose.Slides for .NET.

// This example illustrates basic presentation creation and formatting steps

// for PowerPoint automation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide Size, Widescreen, Background,

// Color, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate setting PPTX slide size to widescreen.

// - Apply a solid background color to slides programmatically.

// - Generate PowerPoint files with predefined layout and styling.

// - Integrate slide size and background customization into .NET applications.

// -----------------------------------------------------------------------------

using System;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



class Program

{

    static void Main()

    {

        // Create a new presentation

        Presentation presentation = new Presentation();



        // Set slide size to widescreen 16:9 with EnsureFit scaling

        presentation.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.EnsureFit);



        // Change background of the first slide to blue

        presentation.Slides[0].Background.Type = BackgroundType.OwnBackground;

        presentation.Slides[0].Background.FillFormat.FillType = FillType.Solid;

        presentation.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.Blue;



        // Save the presentation

        string outputPath = "WidescreenPresentation.pptx";

        presentation.Save(outputPath, SaveFormat.Pptx);

    }

}

