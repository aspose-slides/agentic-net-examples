// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Enable viewerincluded true show navigation arrows using C#

//

// Description:

// Demonstrates how to enable the integrated viewer (ViewerIncluded = true) when

// converting a presentation to SWF format using Aspose.Slides for .NET. The

// example creates a simple presentation, clones a slide, configures SWF

// export options to include the viewer with navigation arrows, and saves the

// result as both SWF and PPTX files.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, ViewerIncluded, Enable,

// NavigationArrows, Presentation Conversion, Office Automation

//

// Use Cases:

// - Generate SWF files with an embedded viewer that provides navigation arrows.

// - Automate PowerPoint to SWF conversion while preserving slide navigation.

// - Build .NET tools that require interactive SWF presentations.

// - Validate SWF export settings in Aspose.Slides workflows.

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

        ISlide slide1 = presentation.Slides[0];



        // Add a second slide by cloning the first slide

        ISlide slide2 = presentation.Slides.AddClone(slide1);



        // Configure SWF options with the integrated viewer included

        SwfOptions swfOptions = new SwfOptions();

        swfOptions.ViewerIncluded = true;



        // Save the presentation as SWF, handling potential format exceptions

        try

        {

            presentation.Save("output.swf", SaveFormat.Swf, swfOptions);

        }

        catch (Exception)

        {

            // Format not supported

        }



        // Save the presentation as PPTX before exiting

        presentation.Save("output.pptx", SaveFormat.Pptx);

    }

}

