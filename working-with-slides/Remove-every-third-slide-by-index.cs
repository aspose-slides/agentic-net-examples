// -----------------------------------------------------------------------------
// Example: Remove every third slide by index using C#
//
// Description:
// Demonstrates how to remove every third slide from a PowerPoint presentation
// by its zero‑based index using C# and Aspose.Slides for .NET. The example loads
// an input PPTX file, iterates through the slides, removes slides whose
// 1‑based position is a multiple of three, and saves the result to a new file.
// This pattern can be used to automate slide cleanup or custom presentation
// transformations in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Every, Third, Slide, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of every third slide in bulk presentations.
// - Build C# utilities for PowerPoint slide management.
// - Pre‑process PPTX files before publishing or further editing.
// - Integrate slide filtering logic into larger .NET workflows.
// -----------------------------------------------------------------------------

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
