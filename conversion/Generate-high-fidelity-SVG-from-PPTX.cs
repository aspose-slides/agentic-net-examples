using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgExportExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                var inputPath = "input.pptx";
                var outputDir = "svg_output";

                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                using (var presentation = new Presentation(inputPath))
                {
                    var options = new SVGOptions();
                    options.VectorizeText = true;

                    for (var i = 0; i < presentation.Slides.Count; i++)
                    {
                        var slide = presentation.Slides[i];
                        var svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                        using (var fileStream = File.Create(svgPath))
                        {
                            slide.WriteAsSvg(fileStream, options);
                        }
                    }

                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}