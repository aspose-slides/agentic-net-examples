// -----------------------------------------------------------------------------
// Example: Delete orphaned layouts after slide removal using C#
// 
// Description:
// Demonstrates how to delete orphaned layout slides after removing a slide from a presentation using C# and Aspose.Slides for .NET. The program creates a sample PPTX if none exists, removes the first slide, cleans up unused layout slides, and saves the result. This ensures presentation integrity in automated PPTX workflows.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Delete orphaned layouts, Slide removal
// 
// Use Cases:
// - Automate removal of unused layout slides after slide deletion.
// - Build C# tools for PowerPoint presentation cleanup.
// - Ensure layout consistency in batch PPTX processing.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace CleanUnusedLayouts
{
    class Program
    {
        static int Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Ensure sample input exists
            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                    // Add a second slide to have more than one slide
                    samplePresentation.Slides.AddEmptySlide(samplePresentation.Slides[0].LayoutSlide);
                    samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePresentation.Dispose();
                    Console.WriteLine("Sample input file created: " + inputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample input file: " + ex.Message);
                    Environment.ExitCode = 1;
                    return 1;
                }
            }

            // Verify that the input file exists before processing
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                Environment.ExitCode = 1;
                return 1;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Remove the first slide if any exist
                    if (presentation.Slides.Count > 0)
                    {
                        presentation.Slides.RemoveAt(0);
                    }

                    // Remove layout slides that are no longer referenced
                    presentation.LayoutSlides.RemoveUnused();

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation processed successfully. Output saved to: " + outputPath);
                Environment.ExitCode = 0;
                return 0;
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The file format is not supported.");
                Environment.ExitCode = 1;
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.ExitCode = 1;
                return 1;
            }
        }
    }
}
