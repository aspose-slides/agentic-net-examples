// -----------------------------------------------------------------------------
// Example: Batch Apply Uniform Glow Effect to Shapes in Multiple PowerPoint Presentations
//
// Description:
// Demonstrates how to create sample PPTX files if they are missing, then load each
// presentation, iterate through all slides and shapes, enable a uniform glow effect
// with a consistent radius, and save the modified file with a new name. This helps
// automate visual styling across many presentations using C# and Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, batch processing, glow effect, shape styling
//
// Use Cases:
// - Ensure visual consistency by applying the same glow effect to all shapes in a set of presentations.
// - Integrate automated PPTX styling into a .NET build or CI pipeline.
// - Prepare presentations for branding guidelines before distribution.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace BatchGlowEffect
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] presentationFiles = new string[]
            {
                "Presentation1.pptx",
                "Presentation2.pptx",
                "Presentation3.pptx"
            };

            bool errorOccurred = false;

            // Ensure sample presentations exist
            foreach (string filePath in presentationFiles)
            {
                if (!File.Exists(filePath))
                {
                    try
                    {
                        Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                        Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];
                        Aspose.Slides.IAutoShape sampleShape = sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
                        sampleShape.TextFrame.Text = "Sample Shape";
                        samplePres.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);
                        samplePres.Dispose();
                        Console.WriteLine($"Created sample presentation: {filePath}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to create sample file {filePath}: {ex.Message}");
                        errorOccurred = true;
                    }
                }
            }

            // Process each presentation
            foreach (string filePath in presentationFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File not found: {filePath}");
                    errorOccurred = true;
                    continue;
                }

                try
                {
                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
                    {
                        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                        {
                            foreach (Aspose.Slides.IShape shape in slide.Shapes)
                            {
                                shape.EffectFormat.EnableGlowEffect();
                                shape.EffectFormat.GlowEffect.Radius = 5.0;
                            }
                        }

                        string outputPath = Path.Combine(
                            Path.GetDirectoryName(filePath),
                            Path.GetFileNameWithoutExtension(filePath) + "_glow.pptx");

                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                        Console.WriteLine($"Processed and saved: {outputPath}");
                    }
                }
                catch (NotSupportedException)
                {
                    Console.WriteLine($"Unsupported format for file: {filePath}");
                    errorOccurred = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
                    errorOccurred = true;
                }
            }

            Environment.Exit(errorOccurred ? 1 : 0);
        }
    }
}
