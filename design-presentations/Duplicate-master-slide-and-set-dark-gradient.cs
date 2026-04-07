using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Get the first master slide
                IMasterSlide sourceMaster = pres.Masters[0];

                // Duplicate the master slide and insert at position 0
                IMasterSlide duplicatedMaster = pres.Masters.InsertClone(0, sourceMaster);

                // Set background of the duplicated master to a dark gradient
                duplicatedMaster.Background.Type = BackgroundType.OwnBackground;
                duplicatedMaster.Background.FillFormat.FillType = FillType.Gradient;
                duplicatedMaster.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Format not supported.
            }
        }
    }
}