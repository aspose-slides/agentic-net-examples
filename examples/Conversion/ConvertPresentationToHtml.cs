using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation file
        string sourcePath = "input.pptx";
        // Path to the output HTML file
        string outputPath = "output.html";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Convert and save the presentation as HTML
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html);
        }
    }
}