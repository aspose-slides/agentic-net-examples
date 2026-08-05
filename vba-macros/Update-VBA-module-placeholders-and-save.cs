// -----------------------------------------------------------------------------
// Example: Update placeholder text in a PowerPoint presentation and save using C#
//
// Description:
// Demonstrates how to load a PPTX file, iterate over shapes on the first slide,
// replace placeholder text, and save the modified presentation using Aspose.Slides
// for .NET. The example shows the required presentation‑processing steps for
// PowerPoint files and produces the updated output in a standalone console
// application. Developers can use this pattern to automate PPTX workflows,
// update slide content, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Placeholder, Text Replacement,
// Save, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate placeholder text replacement in PPTX files.
// - Build C# utilities for PowerPoint content updates.
// - Generate or modify presentations programmatically.
// - Validate and preprocess slides before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplacePlaceholderText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
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
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Replace placeholder text
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape.Placeholder != null)
                    {
                        ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = "New Placeholder Text";
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Placeholder text replaced and presentation saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs, web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
