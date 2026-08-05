// -----------------------------------------------------------------------------
// Example: Add placeholder slide and set tags using C#
//
// Description:
// Demonstrates how to add a content placeholder to a blank layout slide,
// assign a name tag to the placeholder, and create a new slide based on that
// layout using Aspose.Slides for .NET. The example shows the essential steps
// for manipulating placeholders and saving the resulting presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Placeholder, Slide, Tags,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically add placeholders to slide layouts.
// - Tag placeholders for later content updates.
// - Generate PPTX files with custom slide structures in .NET applications.
// - Automate PowerPoint presentation creation and modification.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "PlaceholderSlide.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Get a blank layout slide
        ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);

        // Get the placeholder manager for the layout
        ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

        // Add a content placeholder to the layout
        IAutoShape contentPlaceholder = placeholderManager.AddContentPlaceholder(10f, 10f, 300f, 200f);

        // Tag the placeholder for dynamic updates
        contentPlaceholder.Name = "DynamicContent";

        // Add a new empty slide based on the layout
        ISlide slide = pres.Slides.AddEmptySlide(layout);

        // Save the presentation
        pres.Save(outputPath, SaveFormat.Pptx);

        // Clean up
        pres.Dispose();
    }
}
