// -----------------------------------------------------------------------------
// Example: Batch apply uniform glow to shapes using C#
//
// Description:
// Demonstrates how to batch apply a uniform glow effect to all shapes across
// multiple PowerPoint presentations using C# and Aspose.Slides for .NET.
// The example loads each presentation, iterates through its slides and shapes,
// enables the glow effect with a consistent radius, and saves the modified
// file with a new name. This pattern helps automate PPTX workflows, validate
// visual consistency, or integrate presentation processing into .NET apps.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Batch, Apply, Uniform, Glow,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate batch application of uniform glow to shapes in multiple presentations.
// - Build C# tools for PowerPoint presentation processing and visual styling.
// - Generate or transform PPTX files with consistent visual effects in .NET.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchGlowEffect
{
    class Program
    {
        static void Main(string[] args)
        {
            // List of presentation files to process
            string[] presentationFiles = new string[]
            {
                "Presentation1.pptx",
                "Presentation2.pptx",
                "Presentation3.pptx"
            };

            foreach (string filePath in presentationFiles)
            {
                // Verify that the file exists before attempting to load
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File not found: {filePath}");
                    continue;
                }

                try
                {
                    // Load the presentation
                    using (Presentation presentation = new Presentation(filePath))
                    {
                        // Iterate through all slides
                        foreach (ISlide slide in presentation.Slides)
                        {
                            // Iterate through all shapes on the slide
                            foreach (IShape shape in slide.Shapes)
                            {
                                // Enable glow effect and set a uniform radius
                                shape.EffectFormat.EnableGlowEffect();
                                shape.EffectFormat.GlowEffect.Radius = 5.0;
                            }
                        }

                        // Save the modified presentation with a new name
                        string outputPath = Path.Combine(
                            Path.GetDirectoryName(filePath),
                            Path.GetFileNameWithoutExtension(filePath) + "_glow.pptx");

                        presentation.Save(outputPath, SaveFormat.Pptx);
                        Console.WriteLine($"Processed and saved: {outputPath}");
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine($"Unsupported format for file: {filePath}");
                }
                catch (Exception ex)
                {
                    // Handle any other exceptions (e.g., I/O errors, Aspose-specific errors)
                    Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
                }
            }
        }
    }
}
