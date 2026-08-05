// -----------------------------------------------------------------------------
// Example: Add slide with layout and title using C#
//
// Description:
// Demonstrates how to add a new slide with a specific layout and populate its
// title placeholder with dynamic text using C# and Aspose.Slides for .NET.
// The example shows the required presentation-processing steps for PowerPoint
// files and produces the requested output in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide, Layout, Title,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a slide with a chosen layout and dynamic title.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get a Title layout slide; fallback to TitleOnly or Blank if not available
        Aspose.Slides.ILayoutSlide layout = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Title);
        if (layout == null)
        {
            layout = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.TitleOnly);
        }
        if (layout == null)
        {
            layout = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
        }

        // Add a new slide based on the selected layout
        Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(layout);

        // Dynamic title text
        string dynamicTitle = "Dynamic Slide Title";

        // Populate the title placeholder with the dynamic text
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
            {
                string text = null;
                if (shape.Placeholder.Type == Aspose.Slides.PlaceholderType.CenteredTitle ||
                    shape.Placeholder.Type == Aspose.Slides.PlaceholderType.Title)
                {
                    text = dynamicTitle;
                }
                if (text != null)
                {
                    ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = text;
                }
            }
        }

        // Save the presentation
        string outputPath = "OutputPresentation.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
