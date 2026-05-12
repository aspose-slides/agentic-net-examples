using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideMasterGradientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Set gradient background on the first master slide
                    pres.Masters[0].Background.Type = BackgroundType.OwnBackground;
                    pres.Masters[0].Background.FillFormat.FillType = FillType.Gradient;
                    pres.Masters[0].Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format is not supported by Aspose.Slides.
            }
        }
    }
}