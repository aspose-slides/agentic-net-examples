using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Log Aspose.Slides version
                Console.WriteLine("Aspose.Slides version: " + Aspose.Slides.BuildVersionInfo.AssemblyVersion);

                // Convert and save the presentation to PDF using the provided rule
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

                // Dispose the presentation
                pres.Dispose();

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL or web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}