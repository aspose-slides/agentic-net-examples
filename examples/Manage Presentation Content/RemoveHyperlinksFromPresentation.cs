using System;

class Program
{
    static void Main()
    {
        // Load the existing PPT presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access hyperlink queries and remove all hyperlinks from the slides
        Aspose.Slides.IHyperlinkQueries hyperlinkQueries = presentation.HyperlinkQueries;
        hyperlinkQueries.RemoveAllHyperlinks();

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}