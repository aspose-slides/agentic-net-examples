using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the source PowerPoint presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
        try
        {
            // Save the presentation as a multi‑page TIFF image
            presentation.Save("output.tiff", Aspose.Slides.Export.SaveFormat.Tiff);
        }
        finally
        {
            // Ensure resources are released
            presentation.Dispose();
        }
    }
}