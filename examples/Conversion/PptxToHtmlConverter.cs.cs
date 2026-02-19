using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input PPTX file path
        System.String inputPath = "input.pptx";
        // Define output HTML file path
        System.String outputPath = "output.html";

        // Load the presentation from the PPTX file
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Create HTML export options (default options can be used)
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

        // Save the presentation as HTML using the Html format and the options
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

        // Dispose the presentation to release resources
        pres.Dispose();
    }
}