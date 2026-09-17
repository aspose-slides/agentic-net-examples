// -----------------------------------------------------------------------------
// Example: Batch Scaling of 3D Shapes in PowerPoint via JSON Configuration
//
// Description:
// This console application reads a JSON configuration file that specifies
// scaling factors for 3D shapes on particular slides of a PowerPoint PPTX file.
// It uses Aspose.Slides for .NET to load the presentation, apply the scaling
// to the targeted shapes, and saves the modified presentation. The program
// validates the existence of input files and handles any runtime exceptions.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JSON configuration, shape scaling, 3D objects
//
// Use Cases:
// - Automate bulk resizing of 3D objects across multiple slides based on external data.
// - Integrate PowerPoint shape adjustments into a CI/CD pipeline.
// - Provide designers with a repeatable way to apply consistent scaling to assets.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace BatchShapeScaling
{
    public class ScaleEntry
    {
        public int SlideIndex { get; set; }
        public string ShapeName { get; set; }
        public double ScalingFactor { get; set; }
    }

    public class ScaleConfig
    {
        public List<ScaleEntry> Entries { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            string configPath = "config.json";
            string inputPresentationPath = "input.pptx";
            string outputPresentationPath = "output.pptx";

            try
            {
                if (!File.Exists(configPath))
                {
                    Console.WriteLine($"Configuration file not found: {configPath}");
                    return;
                }

                if (!File.Exists(inputPresentationPath))
                {
                    Console.WriteLine($"Input presentation file not found: {inputPresentationPath}");
                    return;
                }

                string jsonContent = File.ReadAllText(configPath);
                ScaleConfig config = System.Text.Json.JsonSerializer.Deserialize<ScaleConfig>(jsonContent);
                if (config == null || config.Entries == null)
                {
                    Console.WriteLine("Invalid configuration format.");
                    return;
                }

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPresentationPath);
                foreach (ScaleEntry entry in config.Entries)
                {
                    if (entry.SlideIndex < 0 || entry.SlideIndex >= presentation.Slides.Count)
                    {
                        Console.WriteLine($"Slide index out of range: {entry.SlideIndex}");
                        continue;
                    }

                    Aspose.Slides.ISlide slide = presentation.Slides[entry.SlideIndex];
                    Aspose.Slides.IShape targetShape = null;
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape.Name != null && shape.Name.Equals(entry.ShapeName, StringComparison.OrdinalIgnoreCase))
                        {
                            targetShape = shape;
                            break;
                        }
                    }

                    if (targetShape == null)
                    {
                        Console.WriteLine($"Shape \"{entry.ShapeName}\" not found on slide {entry.SlideIndex}.");
                        continue;
                    }

                    float newWidth = (float)(targetShape.Width * entry.ScalingFactor);
                    float newHeight = (float)(targetShape.Height * entry.ScalingFactor);
                    targetShape.Width = newWidth;
                    targetShape.Height = newHeight;
                }

                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine($"Presentation saved successfully to {outputPresentationPath}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
