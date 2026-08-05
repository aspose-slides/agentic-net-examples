// -----------------------------------------------------------------------------
// Example: Add title slide and set placeholder using C#
//
// Description:
// Demonstrates how to add a title slide and set its title placeholder text 
// using C# and Aspose.Slides for .NET. The example creates a new presentation, 
// selects an appropriate slide layout (Title, TitleOnly, or Blank), inserts the 
// slide at the beginning of the deck, and programmatically assigns text to the 
// centered title placeholder. The resulting PPTX file is saved to disk.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Title Slide, Placeholder, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate the creation of a title slide with custom text.
// - Build .NET tools for PowerPoint presentation generation or modification.
// - Generate or transform PPTX files in server-side or desktop applications.
// - Validate and test presentation workflows before publishing.
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

        // Output file path
        string outputPath = "TitleSlide.pptx";

        // Get the layout slides collection from the first master slide
        IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;

        // Try to obtain a Title layout; fallback to TitleOnly or Blank if not found
        ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.Title) ??
                                    layoutSlides.GetByType(SlideLayoutType.TitleOnly);
        if (layoutSlide == null)
        {
            layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
        }

        // Insert a new empty slide at position 0 using the selected layout
        ISlide slide = presentation.Slides.InsertEmptySlide(0, layoutSlide);

        // Set the title placeholder text programmatically
        foreach (IShape shape in slide.Shapes)
        {
            if (shape.Placeholder != null && shape is IAutoShape)
            {
                string text = null;
                if (shape.Placeholder.Type == PlaceholderType.CenteredTitle)
                {
                    text = "My Presentation Title";
                }
                if (text != null)
                {
                    ((IAutoShape)shape).TextFrame.Text = text;
                }
            }
        }

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}
