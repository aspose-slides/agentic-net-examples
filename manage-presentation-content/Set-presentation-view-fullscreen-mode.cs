// -----------------------------------------------------------------------------
// Example: Set presentation view fullscreen mode using C#
//
// Description:
// Demonstrates how to configure a PowerPoint presentation to open in full‑screen
// (kiosk) mode using Aspose.Slides for .NET. The example creates a new presentation,
// sets the SlideShowSettings to BrowsedAtKiosk, and saves the file. This pattern
// can be used to automate presentation view settings in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Presentation, SlideShowSettings,
// Fullscreen, Kiosk, View Mode, Office Automation
//
// Use Cases:
// - Create presentations that launch directly in full‑screen kiosk view.
// - Build .NET tools that modify presentation display settings.
// - Automate PPTX generation with predefined slide show behavior.
// - Ensure consistent presentation experience across devices.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Set the presentation to open in full‑screen mode (kiosk view)
            presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.BrowsedAtKiosk();

            // Save the presentation
            presentation.Save("FullScreenPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, I/O errors)
        }
    }
}
