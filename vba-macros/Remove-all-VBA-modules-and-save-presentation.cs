using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveVbaModules
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output_macrofree.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Remove all VBA modules if a VBA project exists
                    if (presentation.VbaProject != null && presentation.VbaProject.Modules.Count > 0)
                    {
                        // Loop until all modules are removed
                        while (presentation.VbaProject.Modules.Count > 0)
                        {
                            // Remove the first module in the collection
                            presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);
                        }
                    }

                    // Save the macro‑free presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}