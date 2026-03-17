using System;
using System.IO;
using Aspose.Slides.Export;

namespace SlideToSvg
{
    class Program
    {
        static void Main()
        {
            try
            {
                var inputPath = "input.pptx";
                var presentation = new Aspose.Slides.Presentation(inputPath);
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
                presentation.Save("output.pptx", SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}