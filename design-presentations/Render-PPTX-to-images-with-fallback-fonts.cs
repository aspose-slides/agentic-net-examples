using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RenderPptxWithFallback
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output paths
                string inputPath = "input.pptx";
                string outputFolder = "output_images";
                string outputPresentation = "output.pptx";

                // Ensure output directory exists
                Directory.CreateDirectory(outputFolder);

                // Load presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Create fallback rules collection
                    IFontFallBackRulesCollection fallbackRules = new FontFallBackRulesCollection();
                    // Add a rule: for Unicode range 0x400-0x4FF use "Times New Roman" as fallback
                    fallbackRules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
                    // Assign the collection to the presentation's FontsManager
                    presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                    // Render each slide to PNG
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        // Get full‑scale image of the slide
                        IImage image = slide.GetImage(1f, 1f);
                        // Build output file name
                        string imagePath = Path.Combine(outputFolder, $"Slide_{i + 1}.png");
                        // Save image as PNG
                        image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                    }

                    // Save the (potentially modified) presentation
                    presentation.Save(outputPresentation, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}