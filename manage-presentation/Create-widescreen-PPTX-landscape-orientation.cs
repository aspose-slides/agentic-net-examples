// -----------------------------------------------------------------------------
// Example: Create widescreen PPTX landscape orientation using C#
//
// Description:
// Demonstrates how to create a widescreen PPTX file with a 16:9 slide size
// and landscape orientation using C# and Aspose.Slides for .NET. The example
// shows how to configure slide dimensions, set orientation, and save the
// presentation as a PPTX file in a console application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Widescreen, 16:9, Landscape,
// Slide Size, Presentation Creation, Office Automation
//
// Use Cases:
// - Generate widescreen PowerPoint presentations programmatically.
// - Build .NET tools that need specific slide dimensions and orientation.
// - Automate creation of PPTX files for webinars, videos, or displays.
// - Ensure consistent slide layout across generated presentations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideSizeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "WidescreenPresentation.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Set slide size to widescreen 16:9 and ensure landscape orientation
                presentation.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
                presentation.SlideSize.Orientation = SlideOrientation.Landscape;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, I/O errors)
                // Comment: format not supported
            }
        }
    }
}
