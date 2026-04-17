using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

namespace RemoveVbaReferences
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            var inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            var outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                var pres = new Presentation(inputPath);

                // Replace existing VBA project with a new empty one (removes all external references)
                pres.VbaProject = new VbaProject();

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation
                pres.Dispose();

                Console.WriteLine("Presentation saved without external VBA references to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL loading issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}