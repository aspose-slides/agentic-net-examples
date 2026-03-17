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
            try
            {
                // Input ODP file path
                string inputPath = "input.odp";

                // Directory to store SVG files
                string outputDirectory = "output_svgs";
                Directory.CreateDirectory(outputDirectory);

                // Load the ODP presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through each slide and save as SVG
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        string svgFilePath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");
                        using (FileStream fileStream = new FileStream(svgFilePath, FileMode.Create))
                        {
                            presentation.Slides[index].WriteAsSvg(fileStream);
                        }
                    }

                    // Save the presentation before exiting (as PPTX)
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}