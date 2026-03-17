using System;
using System.IO;
using Aspose.Slides.Export;

namespace SlideToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inputPath = "input.odp";
                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    for (var i = 0; i < presentation.Slides.Count; i++)
                    {
                        var slide = presentation.Slides[i];
                        var outputPath = $"slide_{i + 1}.svg";
                        using (var fileStream = File.Create(outputPath))
                        {
                            slide.WriteAsSvg(fileStream);
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save("output.odp", Aspose.Slides.Export.SaveFormat.Odp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}