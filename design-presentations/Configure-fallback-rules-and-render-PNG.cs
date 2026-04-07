using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputImagePath = "slide_output.png";
            string outputPresentationPath = "presentation_fallback.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Create fallback rules collection and add a rule
                    Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();
                    fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

                    // Assign the fallback rules to the presentation's FontsManager
                    presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                    // Render the first slide to an image
                    Aspose.Slides.IImage slideImage = presentation.Slides[0].GetImage(1f, 1f);
                    slideImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);

                    // Save the modified presentation
                    presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}