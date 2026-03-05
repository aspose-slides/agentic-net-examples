using System;

class Program
{
    static void Main()
    {
        // Path to the source PowerPoint file
        string sourcePath = "sample.pptx";
        // Path to the output HTML file
        string outputPath = "sample.html";

        // Load the presentation from the file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Convert and save the entire presentation to HTML format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html);
        }
    }
}