// -----------------------------------------------------------------------------
// Example: Duplicate slide modify text and save using C#
//
// Description:
// Demonstrates how to duplicate a slide, modify its text, and save the
// presentation using C# and Aspose.Slides for .NET. The example shows the
// required presentation-processing steps for PowerPoint files and produces
// the requested output in a standalone console application. Developers can
// use this pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Duplicate, Slide, Modify, Text,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate duplicate slide modify text and save.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DuplicateSlideExample
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Ensure there is at least one slide to duplicate
                    if (presentation.Slides.Count == 0)
                    {
                        Console.WriteLine("The presentation contains no slides.");
                        return;
                    }

                    // Get the first slide (index 0)
                    ISlide originalSlide = presentation.Slides[0];

                    // Duplicate the slide and add it to the end of the collection
                    ISlide duplicatedSlide = presentation.Slides.AddClone(originalSlide);

                    // Modify text content on the duplicated slide
                    foreach (IShape shape in duplicatedSlide.Shapes)
                    {
                        // Look for an AutoShape that contains a TextFrame
                        IAutoShape autoShape = shape as IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
                            // Replace the existing text with new content
                            autoShape.TextFrame.Text = "This is the modified text on the duplicated slide.";
                            // Only modify the first matching shape
                            break;
                        }
                    }

                    // Save the presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // The format is not supported for saving
                // Comment: format not supported.
                Console.WriteLine("The requested save format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
