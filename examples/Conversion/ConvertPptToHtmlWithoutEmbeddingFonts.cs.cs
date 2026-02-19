using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.html";

        // Load the presentation from the input file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Create HTML export options (default does not embed fonts)
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

        // Save the presentation as HTML using the specified options
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

        // Dispose the presentation object to release resources
        presentation.Dispose();
    }
}