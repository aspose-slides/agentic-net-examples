using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyDecorativeFlag
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
                // Load presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate over all master slides
                for (int i = 0; i < presentation.Masters.Count; i++)
                {
                    Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[i];

                    // Iterate over all shapes in the master slide
                    for (int j = 0; j < masterSlide.Shapes.Count; j++)
                    {
                        Aspose.Slides.IShape shape = masterSlide.Shapes[j];

                        // Apply decorative flag for accessibility
                        shape.IsDecorative = true;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}