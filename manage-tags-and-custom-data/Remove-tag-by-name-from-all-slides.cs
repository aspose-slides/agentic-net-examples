// -----------------------------------------------------------------------------
// Example: Remove tag by name from all slides using C#
//
// Description:
// Demonstrates how to remove tag by name from all slides using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Name, Slides, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate remove tag by name from all slides.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveTagFromAllSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";
            // Path to the output presentation
            string outputPath = "output.pptx";
            // Name of the tag to remove
            string tagName = "MyTag";

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
                    // Iterate through all slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        // Access the tag collection via slide's custom data
                        ITagCollection tags = slide.CustomData.Tags;
                        // Remove the tag if it exists
                        if (tags.Contains(tagName))
                        {
                            tags.Remove(tagName);
                        }

                        // Verify removal
                        bool stillExists = tags.Contains(tagName);
                        Console.WriteLine("Slide " + (i + 1) + " tag removal verified: " + (!stillExists));
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("The file format is not supported for PPTX.");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Handle unsupported PPT format
                Console.WriteLine("The file format is not supported for PPT.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
