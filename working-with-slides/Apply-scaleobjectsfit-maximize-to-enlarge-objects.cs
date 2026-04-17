using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideSizeScaleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

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
                    // Increase slide size and maximize objects to fill the new size
                    presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.A4Paper, Aspose.Slides.SlideSizeScaleType.Maximize);

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: The format may not be supported by Aspose.Slides.
            }
        }
    }
}