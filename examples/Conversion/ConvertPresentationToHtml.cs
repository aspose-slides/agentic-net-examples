using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string sourceFile = "input.pptx";

        // Path where the HTML output will be saved
        string htmlFile = "output.html";

        // Load the presentation from the file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourceFile))
        {
            // Convert and save the presentation as HTML
            presentation.Save(htmlFile, Aspose.Slides.Export.SaveFormat.Html);
        }
    }
}