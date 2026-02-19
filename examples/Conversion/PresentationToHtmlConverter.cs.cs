using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.html";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Configure HTML export options for responsive SVG layout
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
        htmlOptions.SvgResponsiveLayout = true;

        // Save the presentation as HTML
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

        // Clean up resources
        presentation.Dispose();
    }
}