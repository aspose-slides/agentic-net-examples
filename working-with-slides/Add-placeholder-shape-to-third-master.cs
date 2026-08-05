// -----------------------------------------------------------------------------
// Example: Add a text placeholder shape to the third master slide using C#
//
// Description:
// This example demonstrates how to ensure a presentation contains at least three
// master slides, retrieve the third master slide, access its first layout slide,
// and add a text placeholder shape with specified dimensions. The placeholder
// is populated with sample text and the presentation is saved as a PPTX file.
// It showcases the use of Aspose.Slides for .NET to manipulate master slides
// and placeholders in a console application.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Placeholder, Text Placeholder,
// Master Slide, Third Master, Layout Slide, AutoShape, Presentation Manipulation
//
// Use Cases:
// - Programmatically add placeholders to a specific master slide.
// - Prepare master slide templates for automated slide generation.
// - Automate PowerPoint presentation setup in .NET applications.
// - Ensure consistent placeholder positioning across multiple master slides.
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

        // Ensure there are at least three master slides
        if (presentation.Masters.Count < 3)
        {
            while (presentation.Masters.Count < 3)
            {
                presentation.Masters.AddClone(presentation.Masters[0]);
            }
        }

        // Get the third master slide (index 2)
        IMasterSlide master = presentation.Masters[2];

        // Get the first layout slide of this master
        ILayoutSlide layout = master.LayoutSlides[0];

        // Add a text placeholder with predefined dimensions
        IAutoShape placeholder = layout.PlaceholderManager.AddTextPlaceholder(50f, 50f, 400f, 100f);

        // Add text to the placeholder
        placeholder.AddTextFrame("This is a placeholder on the third master.");

        // Save the presentation
        string outputPath = "Output.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}
