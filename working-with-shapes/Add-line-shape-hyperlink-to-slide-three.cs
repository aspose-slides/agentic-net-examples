// -----------------------------------------------------------------------------
// Example: Add line shape hyperlink to slide two using C#
//
// Description:
// Demonstrates how to add a line shape with an internal hyperlink that
// navigates from the first slide to a newly added second slide using C# and
// Aspose.Slides for .NET. The example shows the required presentation-processing
// steps for PowerPoint files and produces the requested output in a standalone
// console application. Developers can use this pattern to automate PPTX workflows,
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line, Shape, Hyperlink, Slide,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a line shape hyperlink to navigate to a specific slide.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a second slide to navigate to
        Aspose.Slides.ISlide targetSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Add a line shape on the first slide
        Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

        // Assign internal hyperlink to the target slide
        lineShape.HyperlinkClick = new Aspose.Slides.Hyperlink(targetSlide);
        lineShape.HyperlinkClick.Tooltip = "Go to slide 2";

        // Save the presentation
        presentation.Save("LineHyperlink.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
