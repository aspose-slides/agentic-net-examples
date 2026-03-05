using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
        // Remove all hyperlinks from all shapes and frames in the presentation
        presentation.HyperlinkQueries.RemoveAllHyperlinks();
        // Save the presentation after removing hyperlinks
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}