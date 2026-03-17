using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToSvgConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                var inputPath = "input.pptx";
                var outputFolder = "SvgOutput";

                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    for (var i = 0; i < presentation.Slides.Count; i++)
                    {
                        var slide = presentation.Slides[i] as Aspose.Slides.ISlide;
                        var svgPath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");
                        using (var fileStream = File.Create(svgPath))
                        {
                            slide.WriteAsSvg(fileStream);
                        }
                    }

                    // Save the presentation before exiting
                    var savedPath = "output.pptx";
                    presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}