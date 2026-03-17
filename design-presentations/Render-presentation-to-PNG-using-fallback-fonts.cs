using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RenderPresentationWithFallback
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input presentation and output folder
            string inputPath = "input.pptx";
            string outputFolder = "output";

            try
            {
                // Ensure output directory exists
                Directory.CreateDirectory(outputFolder);

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Define fallback font rules (Unicode range 0x400-0x4FF -> Times New Roman)
                    Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();
                    fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
                    presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                    // Render each slide to a PNG image
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[index];
                        Aspose.Slides.IImage slideImage = slide.GetImage(1f, 1f);
                        string outputPath = Path.Combine(outputFolder, $"slide_{index + 1}.png");
                        slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    }

                    // Save the (potentially unchanged) presentation before exiting
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}