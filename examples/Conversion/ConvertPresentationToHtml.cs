using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string sourcePath = "input.pptx";
        // Path where the HTML output will be saved
        string outputPath = "output.html";

        // Load the presentation from the file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Convert and save the entire presentation to HTML format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html);
        }
    }
}