// -----------------------------------------------------------------------------
// Example: Move Slide and Verify New Index in PowerPoint using C#
// 
// Description:
// Demonstrates loading a PPTX file, moving a slide to a new position, verifying
// the slide's new index, and saving the updated presentation with Aspose.Slides
// for .NET. The program creates a sample input file if none exists and includes
// basic error handling for missing files and unsupported formats.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Move Slide, Verify Index, Slide Reorder
// 
// Use Cases:
// - Reorder slides programmatically in a PowerPoint file.
// - Validate slide positions after manipulation.
// - Build .NET tools for automated PPTX editing and quality checks.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;

namespace SlideReorderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Ensure input file exists; create a sample presentation if it does not.
            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                    // Add a second slide to have at least two slides for reordering.
                    Aspose.Slides.ILayoutSlide layout = samplePresentation.Slides[0].LayoutSlide;
                    samplePresentation.Slides.AddEmptySlide(layout);
                    samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePresentation.Dispose();
                    Console.WriteLine("Sample input presentation created at: " + inputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample input file: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load the presentation. The file format may not be supported. " + ex.Message);
                Environment.Exit(1);
            }

            // Ensure there are at least two slides to perform a move.
            if (presentation.Slides.Count < 2)
            {
                try
                {
                    Aspose.Slides.ILayoutSlide layout = presentation.Slides[0].LayoutSlide;
                    presentation.Slides.AddEmptySlide(layout);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to add additional slide: " + ex.Message);
                    presentation.Dispose();
                    Environment.Exit(1);
                }
            }

            Aspose.Slides.ISlide slideToMove = presentation.Slides[0];
            int targetIndex = 1; // Move to second position (zero‑based index).

            // Adjust target index if out of range.
            if (targetIndex < 0)
            {
                targetIndex = 0;
            }
            else if (targetIndex >= presentation.Slides.Count)
            {
                targetIndex = presentation.Slides.Count - 1;
            }

            try
            {
                presentation.Slides.Reorder(targetIndex, slideToMove);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to reorder slide: " + ex.Message);
                presentation.Dispose();
                Environment.Exit(1);
            }

            int newIndex = presentation.Slides.IndexOf(slideToMove);
            Console.WriteLine("Slide moved to index: " + newIndex);

            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save the presentation: " + ex.Message);
                presentation.Dispose();
                Environment.Exit(1);
            }

            presentation.Dispose();
        }
    }
}
