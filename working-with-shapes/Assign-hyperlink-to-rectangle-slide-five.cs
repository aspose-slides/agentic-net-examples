// -----------------------------------------------------------------------------
// Example: Assign hyperlink to rectangle slide five using C#
//
// Description:
// Demonstrates how to assign an internal hyperlink to a rectangle shape that
// navigates to slide five using C# and Aspose.Slides for .NET. The example
// creates a presentation, adds a rectangle with a text label, ensures that
// slide five exists, links the rectangle to that slide, and saves the result.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Assign, Hyperlink, Rectangle,
// Slide, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate assigning a hyperlink to a rectangle on slide five.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle shape
            IAutoShape shape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 50);

            // Add a text frame to the shape (optional)
            shape.AddTextFrame("Go to Slide 5");

            // Ensure that slide five exists; add empty slides if necessary
            while (presentation.Slides.Count < 5)
            {
                presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Get the target slide (slide index is zero‑based, so index 4 is slide five)
            ISlide targetSlide = presentation.Slides[4];

            // Set an internal hyperlink on the shape that navigates to slide five
            shape.HyperlinkManager.SetInternalHyperlinkClick(targetSlide);

            // Save the presentation
            presentation.Save("HyperlinkToSlide5.pptx", SaveFormat.Pptx);
        }
    }
}
