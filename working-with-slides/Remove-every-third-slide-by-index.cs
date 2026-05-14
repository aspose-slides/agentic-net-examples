using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveEveryThirdSlide
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Remove every third slide (indices 2, 5, 8, ...)
                int index = 0;
                while (index < pres.Slides.Count)
                {
                    // (index + 1) % 3 == 0 identifies every third slide (1‑based counting)
                    if ((index + 1) % 3 == 0)
                    {
                        // Remove slide at the current index
                        pres.Slides.RemoveAt(index);
                        // Do not increment index because the next slide shifts into the current position
                    }
                    else
                    {
                        index++;
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}