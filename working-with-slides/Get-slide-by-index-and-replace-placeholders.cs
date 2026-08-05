// -----------------------------------------------------------------------------
// Example: Get slide by index and replace placeholders using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation, access a slide by its
// zero‑based index, iterate through its shapes, replace any placeholder text
// with a custom string, and save the modified presentation. The example uses
// Aspose.Slides for .NET in a simple console application and shows the essential
// steps for slide‑level processing and placeholder manipulation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide Index, Placeholder, Text Replacement, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate retrieval of a specific slide and update its placeholder content.
// - Build C# utilities for batch processing of PPTX files to replace template text.
// - Integrate slide‑level editing into .NET applications that generate or modify presentations.
// - Validate and test placeholder replacement logic before publishing presentations.
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
            // Path to the source presentation
            string sourcePath = "input.pptx";
            // Path to the output presentation
            string outputPath = "output.pptx";

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine($"Source file not found: {sourcePath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(sourcePath))
                {
                    // Zero‑based slide index to process
                    int slideIndex = 0;

                    // Ensure the index is within range
                    if (slideIndex < 0 || slideIndex >= presentation.Slides.Count)
                    {
                        Console.WriteLine($"Slide index {slideIndex} is out of range.");
                        return;
                    }

                    // Access the slide by index
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Check if the shape has a placeholder and is an AutoShape
                        if (shape.Placeholder != null && shape is IAutoShape)
                        {
                            // Replace placeholder text with actual content
                            IAutoShape autoShape = (IAutoShape)shape;
                            autoShape.TextFrame.Text = "Replaced Content";
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine($"Unsupported PPTX format: {ex.Message}");
            }
            catch (PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine($"Unsupported PPT format: {ex.Message}");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
