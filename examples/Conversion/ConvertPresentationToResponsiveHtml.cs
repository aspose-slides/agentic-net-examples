using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string sourcePath = "input.pptx";
        // Path to the output HTML file
        string outputPath = "output.html";

        // Load the presentation from the file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Create HTML5 export options (responsive by default)
            Aspose.Slides.Export.Html5Options options = new Aspose.Slides.Export.Html5Options();

            // Save the presentation as responsive HTML5
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, options);
        }
    }
}