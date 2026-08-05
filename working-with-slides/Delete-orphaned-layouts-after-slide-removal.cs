// -----------------------------------------------------------------------------
// Example: Delete orphaned layouts after slide removal using C#
//
// Description:
// Demonstrates how to delete orphaned layout slides after removing a slide 
// from a presentation using C# and Aspose.Slides for .NET. The example loads a 
// PPTX file, removes the first slide, cleans up any layout slides that are no 
// longer referenced, and saves the result. This pattern helps automate PPTX 
// workflows, ensure presentation integrity, and integrate layout management 
// into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Delete, Orphaned, Layouts, 
// After, Slide Removal, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of unused layout slides after slide deletion.
// - Build C# tools for PowerPoint presentation cleanup.
// - Generate or transform PPTX files while maintaining layout consistency.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

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
