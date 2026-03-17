using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToSvgExport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source PPTX file
                string inputPath = "input.pptx";

                // Directory where SVG files will be saved
                string outputDirectory = "output";
                Directory.CreateDirectory(outputDirectory);

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through each slide and export as SVG
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        string svgFilePath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");
                        using (FileStream fileStream = File.Create(svgFilePath))
                        {
                            presentation.Slides[index].WriteAsSvg(fileStream);
                        }
                    }

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}