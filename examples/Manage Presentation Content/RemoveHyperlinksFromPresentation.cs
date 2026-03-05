using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the presentation from a PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
        // Remove all hyperlinks from the presentation
        presentation.HyperlinkQueries.RemoveAllHyperlinks();
        // Save the presentation back to PPTX format
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        // Release resources
        presentation.Dispose();
    }
}