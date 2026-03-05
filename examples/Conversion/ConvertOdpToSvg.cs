using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OdpToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input ODP file path (first argument or default)
            var inputPath = args.Length > 0 ? args[0] : "input.odp";

            // Load the ODP presentation
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides and save each as SVG
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    var svgFileName = $"slide_{i + 1}.svg";

                    using (var fileStream = System.IO.File.Create(svgFileName))
                    {
                        slide.WriteAsSvg(fileStream);
                    }
                }

                // Save the presentation (required before exit)
                var outputPath = "output.odp";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);
            }
        }
    }
}