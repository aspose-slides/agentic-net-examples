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
                // Input PowerPoint file
                string inputPath = "input.pptx";

                // Output directory for SVG files
                string outputDir = "output";
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides and save each as SVG
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        string svgPath = Path.Combine(outputDir, $"slide_{index + 1}.svg");
                        using (FileStream fileStream = File.Create(svgPath))
                        {
                            slide.WriteAsSvg(fileStream);
                        }
                    }

                    // Save the presentation before exiting (optional, using a supported format)
                    string savedPresentationPath = "saved_output.pptx";
                    presentation.Save(savedPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}