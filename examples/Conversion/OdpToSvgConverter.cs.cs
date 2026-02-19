using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input ODP file path
        string inputPath = "input.odp";
        // Output HTML file path (contains SVG images)
        string outputPath = "output.html";

        // Override paths if provided as command‑line arguments
        if (args.Length >= 2)
        {
            inputPath = args[0];
            outputPath = args[1];
        }

        // Load the ODP presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Create SVG options for slide image conversion
            Aspose.Slides.Export.SVGOptions svgOpts = new Aspose.Slides.Export.SVGOptions();

            // Set slide image format to SVG using the SVG options
            Aspose.Slides.Export.SlideImageFormat slideImgFmt = Aspose.Slides.Export.SlideImageFormat.Svg(svgOpts);

            // Configure HTML export options to use the SVG slide image format
            Aspose.Slides.Export.HtmlOptions htmlOpts = new Aspose.Slides.Export.HtmlOptions();
            htmlOpts.SlideImageFormat = slideImgFmt;

            // Save the presentation as HTML (slides are rendered as SVG)
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOpts);
        }
    }
}