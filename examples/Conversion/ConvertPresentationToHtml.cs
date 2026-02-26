using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string inputPath = "input.pptx";
        // Path where the HTML output will be saved
        string outputPath = "output.html";

        // Load the presentation from the specified file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Save the presentation in HTML format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html);
        }
    }
}