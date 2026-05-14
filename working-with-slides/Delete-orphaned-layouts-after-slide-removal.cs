using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CleanUnusedLayouts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Example: remove a slide that might reference a specific layout
                    if (presentation.Slides.Count > 0)
                    {
                        // Remove the first slide (adjust index as needed)
                        presentation.Slides.RemoveAt(0);
                    }

                    // Clean up layout slides that are no longer used
                    presentation.LayoutSlides.RemoveUnused();

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            // Handle case where the file format is not supported
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}