using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "sample.pptx";
            string outputPath = args.Length > 1 ? args[1] : "sample_converted.ppt";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the PPTX presentation
                Presentation presentation = new Presentation(inputPath);

                // Note: Advanced effects may be rasterized when saving to PPT format
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}