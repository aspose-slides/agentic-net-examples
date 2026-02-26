using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        var sourcePath = "input.pptx";
        // Path to the output HTML file
        var outputPath = "output.html";

        // Load the presentation
        using (var presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Configure HTML export options for high‑quality images
            var htmlOptions = new Aspose.Slides.Export.HtmlOptions();
            // Use the default slide image format (raster) and set maximum JPEG quality
            htmlOptions.SlideImageFormat = new Aspose.Slides.Export.SlideImageFormat();
            htmlOptions.JpegQuality = 100;

            // Save the presentation as HTML with the specified options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
        }
    }
}