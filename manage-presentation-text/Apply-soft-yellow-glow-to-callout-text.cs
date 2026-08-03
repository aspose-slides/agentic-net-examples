// -----------------------------------------------------------------------------
// Example: Apply soft yellow glow to callout text using C#
//
// Description:
// Demonstrates how to apply a soft yellow glow effect to the text of callout
// shapes in a PowerPoint presentation using C# and Aspose.Slides for .NET.
// The example loads an existing PPTX file, searches for AutoShape objects whose
// alternative text contains the word "Callout", and adds a glow effect to the
// first text portion of each matching shape. The modified presentation is then
// saved as a new file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Soft, Yellow, Glow,
// Callout, Text Formatting, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate the addition of a soft yellow glow to callout text in presentations.
// - Build C# utilities for enhancing visual emphasis in PowerPoint files.
// - Generate or transform PPTX files with custom text effects in .NET applications.
// - Validate and preview presentation styling before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace ApplySoftYellowGlow
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_with_glow.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    foreach (ISlide slide in pres.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Process only AutoShape objects that have alternative text indicating a callout
                            IAutoShape autoShape = shape as IAutoShape;
                            if (autoShape != null && !string.IsNullOrEmpty(autoShape.AlternativeText) && autoShape.AlternativeText.IndexOf("Callout", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                // Ensure the shape has a text frame and at least one paragraph/portion
                                if (autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0 && autoShape.TextFrame.Paragraphs[0].Portions.Count > 0)
                                {
                                    // Enable glow effect for the first portion
                                    IEffectFormat effectFormat = autoShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.EffectFormat;
                                    effectFormat.EnableGlowEffect();

                                    // Configure the glow effect (soft yellow)
                                    IGlow glow = effectFormat.GlowEffect;
                                    // Set color to soft yellow (RGB 255,255,200) with a slight transparency via color transform
                                    glow.Color.R = 255;
                                    glow.Color.G = 255;
                                    glow.Color.B = 200;
                                    glow.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.6f);
                                    // Set a modest radius for a soft appearance
                                    glow.Radius = 5.0;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
