// -----------------------------------------------------------------------------
// Example: Set advanceaftertime to zero for section using C#
//
// Description:
// Demonstrates how to set the SlideShowTransition.AdvanceAfterTime property to
// zero for all slides within a specific section of a presentation using
// Aspose.Slides for .NET. The example creates a new presentation, adds slides,
// defines a section, configures manual navigation for the section's slides,
// and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, AdvanceAfterTime, Zero,
// Section, SlideShowTransition, Manual Navigation, Presentation Processing
//
// Use Cases:
// - Ensure slides in a section advance only on mouse click.
// - Build .NET tools that programmatically configure slide transitions.
// - Automate creation of presentations with custom navigation behavior.
// - Validate or modify existing PPTX files for specific section settings.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "SectionManualNavigation.pptx");
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add additional slides
            Aspose.Slides.ISlide slide1 = pres.Slides[0];
            Aspose.Slides.ISlide slide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
            Aspose.Slides.ISlide slide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

            // Create a section starting with slide2
            Aspose.Slides.ISection section = pres.Sections.AddSection("Manual Navigation Section", slide2);

            // Set transition for slides in the section to require manual navigation (AdvanceAfterTime = 0)
            pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
            pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 0;
            pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
            pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 0;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.NotSupportedException)
        {
            // Format not supported
        }
        catch (System.Exception)
        {
            // Handle other exceptions (e.g., file I/O, network)
        }
    }
}
