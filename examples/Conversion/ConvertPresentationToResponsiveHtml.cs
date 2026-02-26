using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string sourcePath = "input.pptx";
        // Path to the output HTML file
        string outputPath = "output.html";

        // Load the presentation from the file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath);

        // Create HTML export options (default responsive layout)
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

        // Save the presentation as responsive HTML
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

        // Ensure the presentation is properly disposed before exiting
        presentation.Dispose();
    }
}