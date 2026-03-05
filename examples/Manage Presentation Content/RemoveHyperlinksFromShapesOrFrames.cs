using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load the PPTX presentation from file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Remove all hyperlinks (click and mouse‑over) from all shapes and frames in the presentation
        presentation.HyperlinkQueries.RemoveAllHyperlinks();

        // Save the updated presentation back to PPTX format
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}