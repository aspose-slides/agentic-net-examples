using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Export.Xaml;

namespace SlidesToXaml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Output directory for XAML files
            string outputDir = Path.Combine(Environment.CurrentDirectory, "XamlOutput");

            // Create output directory if it does not exist
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Change current directory to output directory so that XAML files are saved there
            Environment.CurrentDirectory = outputDir;

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Save all slides as XAML markup
                pres.Save(new XamlOptions { ExportHiddenSlides = true });

                // Dispose the presentation
                pres.Dispose();

                Console.WriteLine("Presentation successfully exported to XAML files in: " + outputDir);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for XAML export.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}