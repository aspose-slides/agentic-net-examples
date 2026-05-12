using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesAsyncRendering
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Input presentation path
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Create and configure font fallback rules
                IFontFallBackRulesCollection rules = new FontFallBackRulesCollection();
                rules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
                pres.FontsManager.FontFallBackRulesCollection = rules;

                // Asynchronously render each slide to an image
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    int slideIndex = i; // capture for closure
                    string outputImagePath = $"slide_{slideIndex + 1}.png";

                    // Render slide image on a background thread
                    IImage image = await Task.Run(() => pres.Slides[slideIndex].GetImage(1f, 1f));

                    // Save the rendered image
                    image.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                    image.Dispose();
                }

                // Save the presentation after processing
                pres.Save("output.pptx", SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}