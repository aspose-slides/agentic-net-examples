using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Create HTML export options
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

            // Configure slide image format to SVG
            Aspose.Slides.Export.SVGOptions svgOptions = new Aspose.Slides.Export.SVGOptions();
            htmlOptions.SlideImageFormat = Aspose.Slides.Export.SlideImageFormat.Svg(svgOptions);

            // Enable responsive layout (remove width/height attributes from SVG)
            htmlOptions.SvgResponsiveLayout = true;

            // Save the presentation as responsive HTML
            presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
        }
    }
}