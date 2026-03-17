using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input ODP file path
                string inputPath = "input.odp";

                // Directory to store generated SVG files
                string outputDirectory = "output_svgs";
                Directory.CreateDirectory(outputDirectory);

                // Load the ODP presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides and save each as SVG
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[index];
                        string svgFilePath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");

                        using (FileStream fileStream = File.Create(svgFilePath))
                        {
                            // Optional SVG options (e.g., vectorize text)
                            Aspose.Slides.Export.SVGOptions svgOptions = new Aspose.Slides.Export.SVGOptions();
                            svgOptions.VectorizeText = true;

                            // Write slide as SVG with options
                            slide.WriteAsSvg(fileStream, svgOptions);
                        }
                    }

                    // Save the (unchanged) presentation before exiting
                    string savedPresentationPath = "saved_output.pptx";
                    presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}