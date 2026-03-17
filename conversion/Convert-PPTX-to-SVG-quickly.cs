using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input PPTX file path
                string inputPath = "input.pptx";

                // Directory to store generated SVG files
                string outputDirectory = "output_svgs";
                Directory.CreateDirectory(outputDirectory);

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides and save each as SVG
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        string svgFilePath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");

                        using (FileStream fileStream = File.Create(svgFilePath))
                        {
                            slide.WriteAsSvg(fileStream);
                        }
                    }

                    // Save the presentation (no modifications) before exiting
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