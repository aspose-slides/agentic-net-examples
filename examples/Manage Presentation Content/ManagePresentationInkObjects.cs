using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Configure ink options using RenderingOptions (InkOptions are available here)
        Aspose.Slides.Export.RenderingOptions renderingOpts = new Aspose.Slides.Export.RenderingOptions();
        renderingOpts.InkOptions.HideInk = true;                     // Hide ink objects
        renderingOpts.InkOptions.InterpretMaskOpAsOpacity = false; // Use mask operation instead of opacity

        // Save the presentation in PPTX format with the specified ink options
        pres.Save("ManagedInkPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx, renderingOpts);

        // Clean up resources
        pres.Dispose();
    }
}