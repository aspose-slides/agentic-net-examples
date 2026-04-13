using System;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace JsonShapeUpdater
{
    class Program
    {
        // Model representing JSON configuration for shape updates
        private class ShapeConfig
        {
            public int SlideIndex { get; set; }
            public int ShapeIndex { get; set; }
            public string Text { get; set; }
        }

        static void Main(string[] args)
        {
            // Paths (could be passed via args)
            string jsonConfigPath = "config.json";
            string presentationPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify JSON configuration file exists
            if (!File.Exists(jsonConfigPath))
            {
                Console.WriteLine($"Configuration file not found: {jsonConfigPath}");
                return;
            }

            // Verify presentation file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine($"Presentation file not found: {presentationPath}");
                return;
            }

            // Read and deserialize JSON configuration
            ShapeConfig[] configs;
            try
            {
                string jsonContent = File.ReadAllText(jsonConfigPath);
                configs = JsonSerializer.Deserialize<ShapeConfig[]>(jsonContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to read or parse JSON configuration: {ex.Message}");
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation;
            try
            {
                presentation = new Aspose.Slides.Presentation(presentationPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load presentation: {ex.Message}");
                return;
            }

            // Apply configuration to shapes
            foreach (ShapeConfig config in configs)
            {
                // Validate slide index
                if (config.SlideIndex < 0 || config.SlideIndex >= presentation.Slides.Count)
                {
                    Console.WriteLine($"Invalid slide index: {config.SlideIndex}");
                    continue;
                }

                Aspose.Slides.ISlide slide = presentation.Slides[config.SlideIndex];

                // Validate shape index
                if (config.ShapeIndex < 0 || config.ShapeIndex >= slide.Shapes.Count)
                {
                    Console.WriteLine($"Invalid shape index on slide {config.SlideIndex}: {config.ShapeIndex}");
                    continue;
                }

                Aspose.Slides.IShape shape = slide.Shapes[config.ShapeIndex];

                // If shape is an AutoShape, update its text
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape != null && config.Text != null)
                {
                    autoShape.TextFrame.Text = config.Text;
                    continue;
                }

                // If shape is a Chart, demonstrate setting a data label (using existing rule)
                Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                if (chart != null)
                {
                    // Example: show value for the first series data label
                    if (chart.ChartData.Series.Count > 0 && chart.ChartData.Series[0].Labels.Count > 0)
                    {
                        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
                    }
                    continue;
                }

                Console.WriteLine($"Shape at index {config.ShapeIndex} on slide {config.SlideIndex} is not a supported type for update.");
            }

            // Save the updated presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception (commented as per requirement)
                // Format not supported
                Console.WriteLine($"Failed to save presentation: {ex.Message}");
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }
}