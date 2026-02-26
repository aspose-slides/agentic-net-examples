using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string sourcePath = "input.pptx";
        // Path to the output HTML file
        string outputPath = "output.html";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Create default HTML export options (default DPI is 72)
            Aspose.Slides.Export.HtmlOptions options = new Aspose.Slides.Export.HtmlOptions();

            // Save the presentation as HTML
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, options);
        }
    }
}