// -----------------------------------------------------------------------------
// Example: Insert blank slide at beginning apply layout using C#
//
// Description:
// Demonstrates how to insert a blank slide at the beginning of a presentation
// and apply a specific layout using C# and Aspose.Slides for .NET. The example
// shows the required presentation-processing steps for PowerPoint files and
// produces the requested output in a standalone console application. Developers
// can use this pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Blank, Slide,
// Beginning, Layout, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of a blank slide at the beginning with a chosen layout.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the master layout slide collection
                Aspose.Slides.IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;

                // Try to get a predefined layout (TitleAndObject, then Title, then Blank)
                Aspose.Slides.ILayoutSlide layoutSlide = layoutSlides.GetByType(Aspose.Slides.SlideLayoutType.TitleAndObject);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Title);
                }
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
                }

                // Insert a new empty slide at the beginning using the selected layout
                presentation.Slides.InsertEmptySlide(0, layoutSlide);

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
