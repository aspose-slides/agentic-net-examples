using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPT file path
        string inputPath = "input.ppt";

        // Output HTML file path (contains SVG images for each slide)
        string outputPath = "output.html";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Configure HTML options to export slides as SVG
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
        htmlOptions.SlideImageFormat = Aspose.Slides.Export.SlideImageFormat.Svg(new Aspose.Slides.Export.SVGOptions());

        // Save the presentation as HTML with embedded SVG images
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
    }
}