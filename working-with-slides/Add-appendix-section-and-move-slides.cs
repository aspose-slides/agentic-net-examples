// -----------------------------------------------------------------------------
// Example: Add appendix section and move slides using C#
//
// Description:
// Demonstrates how to add an "Appendix" section starting at a specific slide
// and optionally reorder slides using C# and Aspose.Slides for .NET. The example
// loads a PPTX file, creates a new section beginning with slide 12, and saves
// the modified presentation. Developers can adapt this pattern to automate
// section management and slide ordering in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Appendix, Section, Move Slides,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding an appendix section to existing presentations.
// - Build tools that reorganize slide order within sections.
// - Generate or transform PPTX files programmatically in .NET applications.
// - Validate and prepare presentations before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddAppendixSection
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
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Ensure there are enough slides (at least 14)
                    if (pres.Slides.Count < 14)
                    {
                        Console.WriteLine("The presentation does not contain enough slides.");
                        return;
                    }

                    // Add a new section named "Appendix" starting from slide 12 (index 11)
                    ISection appendixSection = pres.Sections.AddSection("Appendix", pres.Slides[11]);

                    // Slides 12 through 14 are now part of the "Appendix" section.
                    // If additional reordering is required, it can be done here.

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            // Handle unsupported file format
            catch (PptxUnsupportedFormatException)
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
