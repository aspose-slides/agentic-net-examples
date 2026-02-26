using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Export the presentation (or specific slides) to HTML format
        // Here we export the entire presentation
        presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html);

        // The presentation is saved before the program exits
    }
}