// -----------------------------------------------------------------------------
// Example: Remove unused layout slides after bulk delete using C#
//
// Description:
// Demonstrates how to delete specific slides from a presentation and then
// remove any layout slides that are no longer referenced, using Aspose.Slides
// for .NET. The example loads a PPTX file, performs bulk slide deletion,
// cleans up unused layout slides, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Unused, Layout, Slides,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cleanup of presentations after bulk slide removal.
// - Build tools that maintain slide layout integrity in .NET applications.
// - Optimize PPTX files by eliminating orphaned layout slides.
// - Integrate presentation processing into CI/CD pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

namespace RemoveUnusedLayoutSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string inputPath = "input.pptx";

            // Verify that the source file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Source file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Example: bulk delete slides at indices 2 and 1 (zero‑based)
                    // Deleting from highest index to lowest prevents shifting issues
                    int[] indicesToDelete = new int[] { 2, 1 };
                    foreach (int slideIndex in indicesToDelete)
                    {
                        if (slideIndex >= 0 && slideIndex < presentation.Slides.Count)
                        {
                            presentation.Slides[slideIndex].Remove();
                        }
                    }

                    // Remove layout slides that are no longer used
                    presentation.LayoutSlides.RemoveUnused();

                    // Save the modified presentation
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
