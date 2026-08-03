// -----------------------------------------------------------------------------
// Example: Validate non empty text placeholder per slide using C#
//
// Description:
// Demonstrates how to validate that each slide in a PowerPoint presentation
// contains at least one non‑empty text placeholder using C# and Aspose.Slides
// for .NET. The example also shows how to set custom prompt text for title and
// subtitle placeholders on the first slide, then saves the modified file.
// This pattern can be used to automate PPTX validation and processing tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Empty, Text,
// Placeholder, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validation of non‑empty text placeholders per slide.
// - Build C# tools for PowerPoint presentation processing and quality checks.
// - Generate or transform PPTX files in .NET applications.
// - Ensure presentation content meets publishing standards before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesPlaceholderValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = Directory.GetCurrentDirectory();
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Check if the input file exists
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
                    // Add custom prompt text to placeholders on the first slide (example modification)
                    ISlide firstSlide = presentation.Slides[0];
                    foreach (IShape shape in firstSlide.Shapes)
                    {
                        if (shape.Placeholder != null && shape is IAutoShape)
                        {
                            string text = null;
                            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle)
                            {
                                text = "Custom Title";
                            }
                            else if (shape.Placeholder.Type == PlaceholderType.Subtitle)
                            {
                                text = "Custom Subtitle";
                            }

                            if (text != null)
                            {
                                ((IAutoShape)shape).TextFrame.Text = text;
                            }
                        }
                    }

                    // Validate that each slide contains at least one non‑empty text placeholder
                    foreach (ISlide slide in presentation.Slides)
                    {
                        bool hasNonEmptyPlaceholder = false;
                        foreach (IShape shape in slide.Shapes)
                        {
                            if (shape.Placeholder != null && shape is IAutoShape)
                            {
                                IAutoShape autoShape = (IAutoShape)shape;
                                if (autoShape.TextFrame != null && !string.IsNullOrEmpty(autoShape.TextFrame.Text))
                                {
                                    hasNonEmptyPlaceholder = true;
                                    break;
                                }
                            }
                        }

                        if (!hasNonEmptyPlaceholder)
                        {
                            Console.WriteLine($"Slide {slide.SlideNumber} does not contain a non‑empty text placeholder.");
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
