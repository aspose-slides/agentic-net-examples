// -----------------------------------------------------------------------------
// Example: Compress remove unused layout slides using C#
//
// Description:
// Demonstrates how to compress a PowerPoint presentation by removing unused
// layout slides using C# and Aspose.Slides for .NET. The example loads a PPTX
// file, optionally deletes a specific slide, invokes the layout slide cleanup
// routine, and saves the optimized presentation. This pattern helps reduce
// file size and improve performance for PowerPoint automation tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compress, Remove, Unused,
// Layout, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of unused layout slides to compress presentations.
// - Build C# utilities for PowerPoint file optimization.
// - Integrate presentation cleanup into .NET applications.
// - Validate and streamline PPTX workflows before distribution.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Example: delete the first slide (layout‑specific slide)
                    if (pres.Slides.Count > 0)
                    {
                        ISlide firstSlide = pres.Slides[0];
                        firstSlide.Remove();
                    }

                    // Remove unused layout slides to reduce file size
                    pres.LayoutSlides.RemoveUnused();

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            // Handle unsupported file format exceptions
            catch (PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
