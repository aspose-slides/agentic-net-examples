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
            // Input ODP file path
            string inputFilePath = "sample.odp";

            // Output directory for SVG files
            string outputDirectory = "SvgOutput";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the ODP presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFilePath);

            // Iterate through each slide and save as SVG
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[index];
                string svgFilePath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");

                using (FileStream fileStream = File.Create(svgFilePath))
                {
                    slide.WriteAsSvg(fileStream);
                }
            }

            // Save the presentation (required before exit)
            presentation.Save("saved_presentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}