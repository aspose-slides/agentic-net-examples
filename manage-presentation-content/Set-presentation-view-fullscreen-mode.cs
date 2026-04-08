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