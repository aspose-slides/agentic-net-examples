// -----------------------------------------------------------------------------
// Example: Insert table placeholder into blank layout using C#
//
// Description:
// Demonstrates how to insert a table placeholder into a blank layout slide using
// C# and Aspose.Slides for .NET. The example creates a new presentation, obtains
// the blank layout, adds a table placeholder with defined position and size, and
// saves the result as a PPTX file. This pattern can be used to automate PPTX
// workflows, validate results, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Table, Placeholder,
// Blank, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of a table placeholder into a blank layout.
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

        // Retrieve a blank layout slide
        Aspose.Slides.ILayoutSlide layoutSlide = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

        // Get the placeholder manager for the layout slide
        Aspose.Slides.ILayoutPlaceholderManager placeholderManager = layoutSlide.PlaceholderManager;

        // Add a table placeholder with specified coordinates (x, y, width, height)
        Aspose.Slides.IAutoShape tablePlaceholder = placeholderManager.AddTablePlaceholder(20f, 20f, 500f, 200f);

        // Save the presentation
        presentation.Save("TablePlaceholderDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
